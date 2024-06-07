using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xunit.runner.BiglandsEngine
{
    class Program
    {
        public static void Main(string[] args) => BiglandsEngineXunitRunner.Main(args, interactiveMode => GameTestBase.ForceInteractiveMode = interactiveMode);
    }
}
