// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core;
using BiglandsEngine.Core.Serialization;

namespace BiglandsEngine.Core.Presentation.Behaviors
{
    /// <summary>
    /// Information about a drag & drop command.
    /// </summary>
    // TODO: Move this in a ViewModel-dedicated assembly
    [DataContract]
    public class DropCommandParameters
    {
        public string DataType { get; set; }
        public object Data { get; set; }
        public object Parent { get; set; }
        public int SourceIndex { get; set; }
        public int TargetIndex { get; set; }
        public object Sender { get; set; }
    }
}
