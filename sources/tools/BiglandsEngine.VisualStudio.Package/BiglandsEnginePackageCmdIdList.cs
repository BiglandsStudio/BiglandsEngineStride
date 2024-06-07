// PkgCmdID.cs
// MUST match PkgCmdID.h
using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;

namespace BiglandsEngine.VisualStudio
{
    static class BiglandsEnginePackageCmdIdList
    {
        public const uint cmdBiglandsEnginePlatformSelect =        0x100;
        public const uint cmdBiglandsEngineOpenWithGameStudio = 0x101;
        public const uint cmdBiglandsEnginePlatformSelectList = 0x102;
        public const uint cmdBiglandsEngineCleanIntermediateAssetsSolutionCommand = 0x103;
        public const uint cmdBiglandsEngineCleanIntermediateAssetsProjectCommand = 0x104;
    };
}