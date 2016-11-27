﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GraphX.Controls;
using GraphX.Controls.Models;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.LayoutAlgorithms;



/* Some notes about the main objects and types in this example:
 * 
 * GraphAreaExample - our custom layout panel derived from the base GraphArea class with custom data types. Presented as object named: Area.
 * GraphExample - our custom data graph derived from BidirectionalGraph class using custom data types.
 * GXLogicCoreExample - our custom logic core that contains all logic settings and algorithms
 * DataVertex - our custom vertex data type.
 * DataEdge - our custom edge data type.
 * Zoombox - zoom control object that handles all zooming and interaction stuff. Presented as object named: zoomctrl.
 * 
 * VertexControl - visual vertex object that is responsible for vertex drawing. Can be found in Area.VertexList collection.
 * EdgeControl - visual edge object that is responsible for edge drawing. Can be found in Area.EdgesList collection.
 */

namespace DMCP_Part_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        Visualizer visualizer;
        public OutputWindow()
        {
            InitializeComponent();
            visualizer = new Visualizer();
            //Customize Zoombox a bit
            //Set minimap (overview) window to be visible by default
            ZoomControl.SetViewFinderVisibility(zoomLeft, Visibility.Visible);
            ZoomControl.SetViewFinderVisibility(zoomRight, Visibility.Visible);

            //Lets setup GraphArea settings
            GraphAreaLogicSetup();

            GraphsRendering();

            zoomLeft.ZoomToFill(); 
            zoomRight.ZoomToFill();
        }
        void GraphsRendering()
        {
            FlowGraphArea.GenerateGraph(FlowGraph());
            IncrementalGraphArea.GenerateGraph(IncrementalGraph());
            FlowGraphArea.SetEdgesDashStyle(EdgeDashStyle.Dash);
            FlowGraphArea.ShowAllEdgesArrows(true);
            FlowGraphArea.ShowAllEdgesLabels(true); 
            
            IncrementalGraphArea.SetEdgesDashStyle(EdgeDashStyle.Dash);
            IncrementalGraphArea.ShowAllEdgesArrows(true);
            IncrementalGraphArea.ShowAllEdgesLabels(true);

            zoomLeft.ZoomToFill();
            zoomRight.ZoomToFill();
        }
     

        private TransportGraph FlowGraph()
        {
            return visualizer.FlowGraphToShow;
        }
        private TransportGraph IncrementalGraph()
        {
            return visualizer.IncrementalGraphToShow;
        }
        private void GraphAreaLogicSetup()
        {
            //Lets create logic core and filled data graph with edges and vertices
            var logicCoreFlow = new GXLogicCore() { Graph = FlowGraph() };
            var logicCoreIncremental = new GXLogicCore() { Graph = FlowGraph() };            
            
            logicCoreIncremental.EnableParallelEdges = true;

            //This property sets layout algorithm that will be used to calculate vertices positions
            //Different algorithms uses different values and some of them uses edge Weight property.
            logicCoreFlow.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.Sugiyama;
            logicCoreIncremental.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.Sugiyama;

            //Now we can set parameters for selected algorithm using AlgorithmFactory property. This property provides methods for
            //creating all available algorithms and algo parameters.
            logicCoreFlow.DefaultLayoutAlgorithmParams = logicCoreFlow.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.Sugiyama);
            logicCoreIncremental.DefaultLayoutAlgorithmParams = logicCoreFlow.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.Sugiyama);

            //Unfortunately to change algo parameters you need to specify params type which is different for every algorithm.
            ((SugiyamaLayoutParameters)logicCoreFlow.DefaultLayoutAlgorithmParams).MinimizeHierarchicalEdgeLong = false;
            ((SugiyamaLayoutParameters)logicCoreFlow.DefaultLayoutAlgorithmParams).PositionCalculationMethod = PositionCalculationMethodTypes.IndexBased;

            ((SugiyamaLayoutParameters)logicCoreIncremental.DefaultLayoutAlgorithmParams).MinimizeHierarchicalEdgeLong = false;
            ((SugiyamaLayoutParameters)logicCoreIncremental.DefaultLayoutAlgorithmParams).PositionCalculationMethod = PositionCalculationMethodTypes.IndexBased;
            //This property sets vertex overlap removal algorithm.
            //Such algorithms help to arrange vertices in the layout so no one overlaps each other.
            logicCoreFlow.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
            logicCoreIncremental.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;

            //Default parameters are created automaticaly when new default algorithm is set and previous params were NULL
            logicCoreFlow.DefaultOverlapRemovalAlgorithmParams.HorizontalGap = 50;
            logicCoreFlow.DefaultOverlapRemovalAlgorithmParams.VerticalGap = 50;
            logicCoreIncremental.DefaultOverlapRemovalAlgorithmParams.HorizontalGap = 50;
            logicCoreIncremental.DefaultOverlapRemovalAlgorithmParams.VerticalGap = 50;
            //This property sets edge routing algorithm that is used to build route paths according to algorithm logic.
            //For ex., SimpleER algorithm will try to set edge paths around vertices so no edge will intersect any vertex.
            //Bundling algorithm will try to tie different edges that follows same direction to a single channel making complex graphs more appealing.
            logicCoreFlow.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;
            logicCoreIncremental.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;

            //This property sets async algorithms computation so methods like: Area.RelayoutGraph() and Area.GenerateGraph()
            //will run async with the UI thread. Completion of the specified methods can be catched by corresponding events:
            //Area.RelayoutFinished and Area.GenerateGraphFinished.
            logicCoreFlow.AsyncAlgorithmCompute = false;
            logicCoreIncremental.AsyncAlgorithmCompute = false;
            //Finally assign logic core to GraphArea object
            FlowGraphArea.LogicCore = logicCoreFlow;
            IncrementalGraphArea.LogicCore = logicCoreIncremental;
        }

        private void Button_Click_NextGraph(object sender, RoutedEventArgs e)
        {
            visualizer.IncGraphListIndex();
            GraphAreaLogicSetup();
            GraphsRendering();
        }

        private void Button_Click_PrevGraph(object sender, RoutedEventArgs e)
        {
            visualizer.DecGgraphListIndex();
            GraphAreaLogicSetup();
            GraphsRendering();
        }

        private void Button_Click_ResultGraph(object sender, RoutedEventArgs e)
        {
            visualizer.LastIndex(); 
            GraphAreaLogicSetup();
            GraphsRendering();
        }


        public int DeltaFlow { get { return visualizer.DeltaFlow; } }

    }
}