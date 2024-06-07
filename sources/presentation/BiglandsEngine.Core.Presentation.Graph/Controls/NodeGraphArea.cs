// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using QuickGraph;
using BiglandsEngine.Core.Presentation.Graph.ViewModel;
using System.Windows;
using GraphX.Controls;

namespace BiglandsEngine.Core.Presentation.Graph.Controls
{    
    /// <summary>
    /// 
    /// </summary>
    public class NodeGraphArea : GraphArea<NodeVertex, NodeEdge, BidirectionalGraph<NodeVertex, NodeEdge>> 
    {
        public virtual event LinkSelectedEventHandler LinkSelected;

        internal virtual void OnLinkSelected(FrameworkElement link)
        {
            LinkSelected?.Invoke(this, new LinkSelectedEventArgs(link));
        }
    }
}
