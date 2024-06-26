// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
namespace BiglandsEngine.TextureConverter.Requests
{
    internal class FlippingSubRequest : FlippingRequest
    {
        public override RequestType Type { get { return RequestType.FlippingSub; } }

        /// <summary>
        /// The index of the sub-image to flip.
        /// </summary>
        public int SubImageIndex;

        public FlippingSubRequest(int index, Orientation orientation)
            : base(orientation)
        {
            SubImageIndex = index;
        }
    }
}
