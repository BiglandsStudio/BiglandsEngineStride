// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Text.Editor;
using NShader;
using NuGet.Common;
using NuGet.Frameworks;
using NuGet.Versioning;
using ServiceWire.NamedPipes;
using BiglandsEngine.Core;
using BiglandsEngine.Core.Assets;
using Process = System.Diagnostics.Process;
using Thread = System.Threading.Thread;

namespace BiglandsEngine.VisualStudio.Commands
{
    /// <summary>
    /// Proxies commands to real <see cref="IBiglandsEngineCommands"/> implementation.
    /// </summary>
    public static class BiglandsEngineCommandsProxy
    {
        public static readonly PackageVersion MinimumVersion = new PackageVersion(4, 0, 0, 0);

        public struct PackageInfo
        {
            public List<string> SdkPaths;

            public PackageVersion ExpectedVersion;

            public PackageVersion LoadedVersion;
        }

        private static string solution;
        private static bool solutionChanged;

        private static readonly object commandProxyLock = new object();

        private static AttachedChildProcessJob BiglandsEngineCommandsProcessJob;
        private static NpClient<IBiglandsEngineCommands> BiglandsEngineCommands = null;

        public static PackageInfo CurrentPackageInfo { get; private set; }

        static BiglandsEngineCommandsProxy()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);

            // Non-signed assemblies need to be manually loaded
            if (assemblyName.Name == "ServiceWire")
                return Assembly.Load(assemblyName);
            if (assemblyName.Name == "BiglandsEngine.VisualStudio.Commands.Interfaces")
                return Assembly.Load(assemblyName);

            return null;
        }

        /// <summary>
        /// Gets the current proxy.
        /// </summary>
        /// <returns>BiglandsEngineCommandsProxy.</returns>
        public static IBiglandsEngineCommands GetProxy()
        {
            lock (commandProxyLock)
            {
                // New instance?
                bool shouldReload = BiglandsEngineCommands == null || solutionChanged || ShouldReload();
                if (!shouldReload)
                {
                    // TODO: Assemblies changed?
                    //shouldReload = ShouldReload();
                }

                // If new instance or assemblies changed, reload
                if (shouldReload)
                {
                    ClosePipeAndProcess();

                    var address = "BiglandsEngine/VSPackageCommands/" + Guid.NewGuid();

                    var BiglandsEnginePackageInfo = FindBiglandsEngineSdkDir(solution).Result;
                    if (BiglandsEnginePackageInfo.LoadedVersion == null)
                        return null;

                    var commandAssembly = BiglandsEnginePackageInfo.SdkPaths.First(x => Path.GetFileNameWithoutExtension(x) == "BiglandsEngine.VisualStudio.Commands");
                    var commandExecutable = LoaderToolLocator.GetExecutable(commandAssembly); // .NET Core: .dll => .exe

                    var startInfo = new ProcessStartInfo
                    {
                        // Note: try to get exec server if it exists, otherwise use CompilerApp.exe
                        FileName = commandExecutable,
                        Arguments = $"--pipe=\"{address}\"",
                        WorkingDirectory = Environment.CurrentDirectory,
                        UseShellExecute = false,
                    };

                    var BiglandsEngineCommandsProcess = new Process { StartInfo = startInfo };
                    BiglandsEngineCommandsProcess.Start();

                    BiglandsEngineCommandsProcessJob = new AttachedChildProcessJob(BiglandsEngineCommandsProcess);

                    for (int i = 0; i < 10; ++i)
                    {
                        try
                        {
                            BiglandsEngineCommands = BiglandsEnginePackageInfo.LoadedVersion >= new PackageVersion("4.2.0")
                                ? new NpClient<IBiglandsEngineCommands>(new NpEndPoint(address + "/IBiglandsEngineCommands"))
                                // For BiglandsEngine 4.1, we were using ServiceWire 5.3.4, which didn't have compressor and used BinaryFormatter serialization
                                // BinaryFormatter was removed from .NET 8.0, ServiceWire 5.5.4 and BiglandsEngine 4.2, but we still need to be able to communicate with previous version of BiglandsEngine
                                // Luckily, since VS still work with .NET 4.7, we can access BinaryFormatter and implement a custom ServiceWire.ISerializer for it.
                                : new NpClient<IBiglandsEngineCommands>(new NpEndPoint(address + "/IBiglandsEngineCommands"), new ServiceWireBinaryFormatterSerializer(), new ServiceWireDoNothingCompressor());
                            break;
                        }
                        catch
                        {
                            // Last try, forward exception
                            if (i == 9)
                                throw;
                            // Wait until process is ready to accept connections
                            Thread.Sleep(100);
                        }
                    }

                    solutionChanged = false;
                }

                return BiglandsEngineCommands?.Proxy;
            }
        }

        private static void ClosePipeAndProcess()
        {
            if (BiglandsEngineCommands != null)
            {
                try
                {
                    BiglandsEngineCommands.Dispose();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Unexpected exception when closing remote connection to VS Commands: {ex}");
                }
                BiglandsEngineCommands = null;
            }

            BiglandsEngineCommandsProcessJob?.Dispose();
            BiglandsEngineCommandsProcessJob = null;
        }

        public static bool ShouldReload()
        {
            // TODO: Check if assemblies/packages were regenerated
            return false;
        }

        /// <summary>
        /// Gets the BiglandsEngine SDK dir.
        /// </summary>
        /// <returns></returns>
        internal static async Task<PackageInfo> FindBiglandsEngineSdkDir(string solution, string packageName = "BiglandsEngine.VisualStudio.Commands")
        {
            // Resolve the sdk version to load from the solution's package
            var packageInfo = new PackageInfo { ExpectedVersion = await PackageSessionHelper.GetPackageVersion(solution), SdkPaths = new List<string>() };

            // Try to find the package with the expected version
            if (packageInfo.ExpectedVersion != null && packageInfo.ExpectedVersion >= MinimumVersion)
            {
                // Try both net8.0 and net472
                var success = false;
                foreach (var folder in new[] { "net8.0-windows7.0", "net472" })
                {
                    var logger = new Logger();
                    var solutionRoot = Path.GetDirectoryName(solution);
                    var (request, result) = await Task.Run(() => RestoreHelper.Restore(logger, NuGetFramework.ParseFolder(folder, DefaultFrameworkNameProvider.Instance), "win", packageName, new VersionRange(packageInfo.ExpectedVersion.ToNuGetVersion()), solutionRoot));
                    if (result.Success)
                    {
                        packageInfo.SdkPaths.AddRange(RestoreHelper.ListAssemblies(result.LockFile));
                        packageInfo.LoadedVersion = packageInfo.ExpectedVersion;
                        success = true;
                        break;
                    }
                }
                if (!success)
                {
                    throw new InvalidOperationException($"Could not restore {packageName} {packageInfo.ExpectedVersion}, this visual studio extension may fail to work properly without it. To fix this you can either build {packageName} or pull the right version from NuGet manually");
                }
            }

            return packageInfo;
        }

        public class Logger : ILogger
        {
            private object logLock = new object();
            public List<(LogLevel Level, string Message)> Logs { get; } = new List<(LogLevel, string)>();

            public void LogDebug(string data)
            {
                Log(LogLevel.Debug, data);
            }

            public void LogVerbose(string data)
            {
                Log(LogLevel.Verbose, data);
            }

            public void LogInformation(string data)
            {
                Log(LogLevel.Information, data);
            }

            public void LogMinimal(string data)
            {
                Log(LogLevel.Minimal, data);
            }

            public void LogWarning(string data)
            {
                Log(LogLevel.Warning, data);
            }

            public void LogError(string data)
            {
                Log(LogLevel.Error, data);
            }

            public void LogInformationSummary(string data)
            {
                Log(LogLevel.Information, data);
            }

            public void LogErrorSummary(string data)
            {
                Log(LogLevel.Error, data);
            }

            public void Log(LogLevel level, string data)
            {
                lock (logLock)
                {
                    Debug.WriteLine($"[{level}] {data}");
                    Logs.Add((level, data));
                }
            }

            public Task LogAsync(LogLevel level, string data)
            {
                Log(level, data);
                return Task.CompletedTask;
            }

            public void Log(ILogMessage message)
            {
                Log(message.Level, message.Message);
            }

            public Task LogAsync(ILogMessage message)
            {
                Log(message);
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Converts a <see cref="PackageVersion"/> into a <see cref="NuGetVersion"/>.
        /// </summary>
        /// <param name="version">The source of conversion.</param>
        /// <returns>A new instance of <see cref="NuGetVersion"/> corresponding to <paramref name="version"/>.</returns>
        public static NuGetVersion ToNuGetVersion(this PackageVersion version)
        {
            if (version == null) throw new ArgumentNullException(nameof(version));

            return new NuGetVersion(version.Version, version.SpecialVersion);
        }

        internal static void SetSolution(string solutionPath)
        {
            solution = solutionPath;
        }


        internal static void SetPackageInfo(PackageInfo BiglandsEnginePackageInfo)
        {
            CurrentPackageInfo = BiglandsEnginePackageInfo;
        }

        internal static void CloseSolution()
        {
            ClosePipeAndProcess();
        }
    }
}
