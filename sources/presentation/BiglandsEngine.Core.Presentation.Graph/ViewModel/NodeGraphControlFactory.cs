// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Windows;
using GraphX;
using GraphX.Controls;
using GraphX.Controls.Models;
using BiglandsEngine.Core.Presentation.Graph.Controls;

namespace BiglandsEngine.Core.Presentation.Graph.ViewModel
{
    /// <summary>
    /// Factory class responsible for NodeVertexControl and NodeEdgeControl objects creation
    /// </summary>
    public class NodeGraphControlFactory : IGraphControlFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphArea"></param>
        public NodeGraphControlFactory(GraphAreaBase graphArea)
        {
            FactoryRootArea = graphArea;
        }

        /// <summary>
        /// Create vertex control.
        /// </summary>
        /// <param name="vertexData"></param>
        /// <returns></returns>
        public VertexControl CreateVertexControl(object vertexData)
        {
            return new NodeVertexControl(vertexData) { RootArea = FactoryRootArea };
        }

        /// <summary>
        /// Create edge control
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="edge"></param>
        /// <param name="showLabels"></param>
        /// <param name="showArrows"></param>
        /// <param name="visibility"></param>
        /// <returns></returns>
        public EdgeControl CreateEdgeControl(VertexControl source, VertexControl target, object edge, bool showArrows = true, Visibility visibility = Visibility.Visible)
        {
            return new NodeEdgeControl(source, target, edge, showArrows) { Visibility = visibility, RootArea = FactoryRootArea };
        }

        /// <summary>
        /// Root graph area for the factory
        /// </summary>
        public GraphAreaBase FactoryRootArea { get; set; }
    }
}
