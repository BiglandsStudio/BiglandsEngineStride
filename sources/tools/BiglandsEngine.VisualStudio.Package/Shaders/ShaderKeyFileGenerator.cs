// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using BiglandsEngine.Core;
using BiglandsEngine.VisualStudio.CodeGenerator;
using BiglandsEngine.VisualStudio.Commands;

namespace BiglandsEngine.VisualStudio.Shaders
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(GuidList.guidBiglandsEngine_VisualStudio_ShaderKeyFileGenerator)]
    [ProvideObject(typeof(ShaderKeyFileGenerator), RegisterUsing = RegistrationMethod.CodeBase)]
    public class ShaderKeyFileGenerator : BaseCodeGeneratorWithSite
    {
        public const string DisplayName = "BiglandsEngine Shader C# Key Generator";
        public const string InternalName = "BiglandsEngineShaderKeyGenerator";

        protected override string GetDefaultExtension()
        {
            // Figure out extension (different in case of versions before 3.1.0.2-beta01)
            if (BiglandsEngineCommandsProxy.CurrentPackageInfo.ExpectedVersion != null
                && BiglandsEngineCommandsProxy.CurrentPackageInfo.ExpectedVersion < new PackageVersion("3.2.0.1-beta02"))
            {
                return ".cs";
            }

            return ".sdsl.cs";
        }

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            try
            {
                return System.Threading.Tasks.Task.Run(() =>
                {
                    var remoteCommands = BiglandsEngineCommandsProxy.GetProxy();
                    return remoteCommands.GenerateShaderKeys(inputFileName, inputFileContent);
                }).Result;
            }
            catch (Exception ex)
            {
                GeneratorError(4, ex.ToString(), 0, 0);

                return null;
            }
        }
    }
}