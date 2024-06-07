using ServiceWire;

namespace BiglandsEngine.VisualStudio.Commands
{
    internal class ServiceWireDoNothingCompressor : ICompressor
    {
        public byte[] Compress(byte[] data)
        {
            return data;
        }

        public byte[] DeCompress(byte[] compressedBytes)
        {
            return compressedBytes;
        }
    }
}
