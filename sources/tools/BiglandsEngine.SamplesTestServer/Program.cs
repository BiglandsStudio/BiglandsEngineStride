// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading;
using BiglandsEngine.Engine.Network;

namespace BiglandsEngine.SamplesTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var samplesServer = new SamplesTestServer();
            try
            {
                samplesServer.TryConnect("127.0.0.1", RouterClient.DefaultPort).Wait();
            }
            catch
            {
                return;
            }          

            // Forbid process to terminate (unless ctrl+c)
            while (true)
            {
                Console.Read();
                Thread.Sleep(100);
            }
        }
    }
}
