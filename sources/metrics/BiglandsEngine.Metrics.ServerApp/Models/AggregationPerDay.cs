﻿using System;

namespace BiglandsEngine.Metrics.ServerApp.Models
{
    /// <summary>
    /// Aggregate data to store metrics results per day.
    /// </summary>
    public class AggregationPerDay : AggregateBase
    {
        public DateTime Date { get; set; }
    }
}