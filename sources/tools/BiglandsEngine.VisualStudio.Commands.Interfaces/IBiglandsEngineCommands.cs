// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using BiglandsEngine.VisualStudio.Commands.Shaders;

namespace BiglandsEngine.VisualStudio.Commands
{
    /// <summary>
    /// Describes BiglandsEngine commands accessed by VS Package to current BiglandsEngine package (so that VSPackage doesn't depend on BiglandsEngine assemblies).
    /// </summary>
    /// <remarks>
    /// WARNING: Removing any of those methods will likely break backwards compatibility!
    /// </remarks>
    public interface IBiglandsEngineCommands
    {
        byte[] GenerateShaderKeys(string inputFileName, string inputFileContent);

        RawShaderNavigationResult AnalyzeAndGoToDefinition(string projectPath, string sourceCode, RawSourceSpan span);
    }
}
