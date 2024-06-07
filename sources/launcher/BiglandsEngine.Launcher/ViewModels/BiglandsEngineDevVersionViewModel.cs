// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Threading.Tasks;
using BiglandsEngine.Core.Annotations;
using BiglandsEngine.Core.IO;
using BiglandsEngine.Core.Packages;

namespace BiglandsEngine.LauncherApp.ViewModels
{
    /// <summary>
    /// An implementation of the <see cref="BiglandsEngineVersionViewModel"/> that represents a non-official version locally built.
    /// </summary>
    internal class BiglandsEngineDevVersionViewModel : BiglandsEngineVersionViewModel
    {
        private readonly UDirectory path;
        private static int devMinorCounter = int.MaxValue;
        private NugetLocalPackage localPackage;
        private bool isDevRedirect;

        internal BiglandsEngineDevVersionViewModel(LauncherViewModel launcher, NugetStore store, [CanBeNull] NugetLocalPackage localPackage, UDirectory path, bool isDevRedirect)
            : base(launcher, store, localPackage, localPackage.Id, int.MaxValue, devMinorCounter--)
        {
            this.path = path;
            this.localPackage = localPackage;
            this.isDevRedirect = isDevRedirect;
            DownloadCommand.IsEnabled = false;
            // Update initial status (IsVisible will be set to true)
            UpdateStatus();
        }

        /// <inheritdoc/>
        public override string Name => "Local " + path.MakeRelative(path.GetParent());

        /// <inheritdoc/>
        public override string DisplayName => localPackage != null ? $"{PackageSimpleName} {localPackage.Version} (local)" : base.DisplayName;

        /// <inheritdoc/>
        public override string FullName => localPackage?.Version.ToString() ?? path.MakeRelative(path.GetParent());

        /// <inheritdoc/>
        public override bool CanBeDownloaded => false;

        // TODO: a distinction between CanDelete and IsInstalled?
        /// <inheritdoc/>
        public override bool CanDelete => isDevRedirect;

        /// <inheritdoc/>
        public override string InstallPath => path.ToWindowsPath();


        // This property is not used because a dev verison cannot be downloaded.
        /// <inheritdoc/>
        protected override string InstallErrorMessage => null;

        // This property is not used because a dev verison cannot be downloaded.
        /// <inheritdoc/>
        protected override string UninstallErrorMessage => null;

        /// <inheritdoc/>
        protected override Task UpdateVersionsFromStore()
        {
            return Launcher.RetrieveLocalBiglandsEngineVersions();
        }

        /// <inheritdoc/>
        protected override void UpdateStatus()
        {
            base.UpdateStatus();
            // A dev version is always local and cannot be downloaded
            DownloadCommand.IsEnabled = false;
        }

        /// <inheritdoc/>
        protected override void UpdateInstallStatus()
        {
            // A dev version cannot be installed
        }
    }
}
