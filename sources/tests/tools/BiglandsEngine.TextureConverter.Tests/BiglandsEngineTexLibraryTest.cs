// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using Xunit;
using BiglandsEngine.TextureConverter.Requests;
using BiglandsEngine.TextureConverter.TexLibraries;

namespace BiglandsEngine.TextureConverter.Tests
{
    public class BiglandsEngineTexLibraryTest : IDisposable
    {
        BiglandsEngineTexLibrary library;

        public BiglandsEngineTexLibraryTest()
        {
            library = new BiglandsEngineTexLibrary();
            Assert.True(library.SupportBGRAOrder());
        }

        public void Dispose()
        {
            library.Dispose();
        }


        [Theory(Skip = "Need check")]
        [InlineData("Texture3D_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureArray_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureCube_WMipMaps_RGBA8888.sd")]
        public void StartLibraryTest(string file)
        {
            TexImage image = TestTools.Load(library, file);

            TexLibraryTest.StartLibraryTest(image, library);

            image.Dispose();
        }


        [Fact(Skip = "Need check")]
        public void CanHandleRequestTest()
        {
            TexImage image = TestTools.Load(library, "Texture3D_WMipMaps_ATC_RGBA_Explicit.sd");
            Assert.False(library.CanHandleRequest(image, new DecompressingRequest(false)));
            Assert.False(library.CanHandleRequest(image, new LoadingRequest(new TexImage(), false)));
            Assert.True(library.CanHandleRequest(image, new LoadingRequest("TextureArray_WMipMaps_BC3.dds", false)));
            Assert.True(library.CanHandleRequest(image, new ExportRequest("TextureArray_WMipMaps_BC3.sd", 0)));
            Assert.True(library.CanHandleRequest(image, new ExportToBiglandsEngineRequest()));
            image.Dispose();
        }


        [Theory(Skip = "Need check")]
        [InlineData("Texture3D_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureArray_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureCube_WMipMaps_RGBA8888.sd")]
        public void ExportTest(string file)
        {
            TexImage image = TestTools.Load(library, file);

            TexLibraryTest.ExportTest(image, library, file);

            image.Dispose();
        }

        [Theory(Skip = "Need check")]
        [InlineData("Texture3D_WMipMaps_ATC_RGBA_Explicit.sd", 4)]
        [InlineData("TextureArray_WMipMaps_ATC_RGBA_Explicit.sd", 512)]
        [InlineData("TextureCube_WMipMaps_RGBA8888.sd", 16)]
        public void ExportTestMinMipmap(string file, int minMipMapSize)
        {
            TexImage image = TestTools.Load(library, file);

            TexLibraryTest.ExportMinMipMapTest(image, library, minMipMapSize);

            image.Dispose();
        }

        [Theory(Skip = "Need check")]
        [InlineData("Texture3D_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureArray_WMipMaps_ATC_RGBA_Explicit.sd")]
        [InlineData("TextureCube_WMipMaps_RGBA8888.sd")]
        public void ExportToBiglandsEngineTest(string file)
        {
            TexImage image = TestTools.Load(library, file);

            ExportToBiglandsEngineRequest request = new ExportToBiglandsEngineRequest();
            library.Execute(image, request);

            var sd = request.XkImage;

            Assert.True(sd.TotalSizeInBytes == image.DataSize);
            Assert.True(sd.Description.MipLevels == image.MipmapCount);
            Assert.True(sd.Description.Width == image.Width);
            Assert.True(sd.Description.Height == image.Height);

            image.Dispose();
        }
    }
}
