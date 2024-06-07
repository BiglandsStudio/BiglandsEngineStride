// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using BiglandsEngine.Core.IO;
using BiglandsEngine.Effects;
using BiglandsEngine.Core.Shaders.Utilities;

namespace BiglandsEngine.Core.Shaders.Tests
{
    class TestOpenGLES
    {
        private void Mount()
        {
            VirtualFileSystem.MountFileSystem("/assets/shaders", "../../ShaderES");
        }

        [Fact]
        public void TestUnroll()
        {
            Mount();

            var fileStream = VirtualFileSystem.OpenStream("/assets/shaders/UnrollTest.hlsl", VirtualFileMode.Open, VirtualFileAccess.Read);
            var sr = new StreamReader(fileStream);
            string source = sr.ReadToEnd();
            fileStream.Close();

            var compilerES = new BiglandsEngine.Graphics.ShaderCompiler.OpenGL.ShaderCompiler(true);
            compilerES.Compile(source, "VSMain", "vs");

            var compiler = new BiglandsEngine.Graphics.ShaderCompiler.OpenGL.ShaderCompiler();
            compiler.Compile(source, "VSMain", "vs");
        }

        [Fact]
        public void TestBreak()
        {
            Mount();

            var fileStream = VirtualFileSystem.OpenStream("/assets/shaders/UnrollBreak.hlsl", VirtualFileMode.Open, VirtualFileAccess.Read);
            var sr = new StreamReader(fileStream);
            string source = sr.ReadToEnd();
            fileStream.Close();

            var compiler = new BiglandsEngine.Graphics.ShaderCompiler.OpenGL.ShaderCompiler(true);
            compiler.Compile(source, "VSMain", "vs");
        }
    }
}
