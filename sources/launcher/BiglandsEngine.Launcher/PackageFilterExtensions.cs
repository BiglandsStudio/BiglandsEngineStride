using System.Collections.Generic;
using System.Linq;
using BiglandsEngine.Core;
using BiglandsEngine.Core.Packages;

namespace BiglandsEngine.LauncherApp
{
    static class PackageFilterExtensions
    {
        public static IEnumerable<T> FilterBiglandsEngineMainPackages<T>(this IEnumerable<T> packages) where T : NugetPackage
        {
            // BiglandsEngine up to 3.0 package is Xenko, 3.x is Xenko.GameStudio, then BiglandsEngine.GameStudio
            return packages.Where(x => (x.Id == "Xenko" && x.Version < new PackageVersion(3, 1, 0, 0))
                                    || (x.Id == "Xenko.GameStudio" && x.Version < new PackageVersion(4, 0, 0, 0))
                                    || (x.Id == "BiglandsEngine.GameStudio"));
        }
    }
}
