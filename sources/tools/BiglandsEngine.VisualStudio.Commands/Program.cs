using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mono.Options;
using ServiceWire.NamedPipes;

namespace BiglandsEngine.VisualStudio.Commands
{
    class Program
    {
        public static void Main(string[] args)
        {
            string pipeAddress = string.Empty;

            var p = new OptionSet
            {
                { "pipe=", "Pipe for communication", v => pipeAddress = v },
            };

            p.Parse(args);

            var host = new NpHost(pipeAddress + "/IBiglandsEngineCommands");
            host.AddService<IBiglandsEngineCommands>(new BiglandsEngineCommands());
            host.Open();

            // Forbid process to terminate (unless ctrl+c)
            while (true)
            {
                Console.Read();
                Thread.Sleep(100);
            }
        }
    }
}
