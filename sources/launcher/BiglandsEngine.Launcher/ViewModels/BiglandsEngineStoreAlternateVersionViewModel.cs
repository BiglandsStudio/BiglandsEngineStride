using BiglandsEngine.Core;
using BiglandsEngine.Core.Annotations;
using BiglandsEngine.Core.Packages;
using BiglandsEngine.Core.Presentation.Commands;
using BiglandsEngine.Core.Presentation.ViewModels;

namespace BiglandsEngine.LauncherApp.ViewModels
{
    internal sealed class BiglandsEngineStoreAlternateVersionViewModel : DispatcherViewModel
    {
        private BiglandsEngineStoreVersionViewModel BiglandsEngineVersion;
        internal NugetServerPackage ServerPackage;
        internal NugetLocalPackage LocalPackage;

        public BiglandsEngineStoreAlternateVersionViewModel([NotNull] BiglandsEngineStoreVersionViewModel BiglandsEngineVersion)
            : base(BiglandsEngineVersion.ServiceProvider)
        {
            this.BiglandsEngineVersion = BiglandsEngineVersion;

            SetAsActiveCommand = new AnonymousCommand(ServiceProvider, () =>
            {
                BiglandsEngineVersion.UpdateLocalPackage(LocalPackage, null);
                if (LocalPackage == null)
                {
                    // If it's a non installed version, offer same version for serverPackage so that it offers to install this specific version
                    BiglandsEngineVersion.UpdateServerPackage(ServerPackage, null);
                }
                else
                {
                    // Otherwise, offer latest version for update
                    BiglandsEngineVersion.UpdateServerPackage(BiglandsEngineVersion.LatestServerPackage, null);
                }

                BiglandsEngineVersion.Launcher.ActiveVersion = BiglandsEngineVersion;
            });
        }

        /// <summary>
        /// Gets the command that will set the associated version as active.
        /// </summary>
        public CommandBase SetAsActiveCommand { get; }

        public string FullName
        {
            get
            {
                return LocalPackage != null ? $"{LocalPackage.Id} {LocalPackage.Version} (installed)" : $"{ServerPackage.Id} {ServerPackage.Version}";
            }
        }

        public PackageVersion Version => LocalPackage?.Version ?? ServerPackage.Version;

        internal void UpdateLocalPackage(NugetLocalPackage package)
        {
            OnPropertyChanging(nameof(FullName), nameof(Version));
            LocalPackage = package;
            OnPropertyChanged(nameof(FullName), nameof(Version));
        }

        internal void UpdateServerPackage(NugetServerPackage package)
        {
            OnPropertyChanging(nameof(FullName), nameof(Version));
            ServerPackage = package;
            OnPropertyChanged(nameof(FullName), nameof(Version));
        }
    }
}
