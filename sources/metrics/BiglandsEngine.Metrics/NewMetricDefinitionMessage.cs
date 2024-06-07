using System;
using System.Diagnostics;

namespace BiglandsEngine.Metrics
{
    [DebuggerDisplay("Metric [{Name} : {MetridId}]")]
    internal class NewMetricDefinitionMessage
    {
        public Guid MetridId { get; set; }

        public string Name { get; set; }
    }
}