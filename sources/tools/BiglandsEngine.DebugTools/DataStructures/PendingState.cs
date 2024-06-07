// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiglandsEngine.Framework.MicroThreading;

namespace BiglandsEngine.DebugTools.DataStructures
{
    internal class MicroThreadPendingState
    {
        internal int ThreadId { get; set; }
        internal double Time { get; set; }
        internal MicroThreadState State { get; set; }
        internal MicroThread MicroThread { get; set; }
    }
}
