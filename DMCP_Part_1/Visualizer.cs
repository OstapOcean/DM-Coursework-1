using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using QuickGraph;
using GraphX.PCL.Logic.Models;


namespace DMCP_Part_1
{

    class Visualizer 
    {
        public void IncreaseListIterator()
        {
            if (ListIterator + 1 < flowGraphsToShow.Count)
            {
                ListIterator += 1;
            }
        }

        private int ListIterator = 0;

        private TransportNetwork transportNet;

        private List<TransportGraph> flowGraphsToShow;
        public TransportGraph FlowGraphToShow
        {
            get
            {
                return flowGraphsToShow!=null ? flowGraphsToShow[ListIterator]:null;
            }
        }

        private List<TransportGraph> incrementalGraphsToShow;
        public TransportGraph IncrementalGraphToShow
        {
            get
            {
                return incrementalGraphsToShow != null ? incrementalGraphsToShow[ListIterator] : null;
            }
        }


        public Visualizer(int givenFlow, int[][] costFlow, int[][] capacity)
        {
            transportNet = new TransportNetwork(capacity, costFlow);
            transportNet.IntermediateTransportNetResult += new IntermediateGraphDelegate(CatchGraps);
            transportNet.FlowMinCost(givenFlow);
        }
        void CatchGraps(object sender,IntermediateTransportNetEventArgs args)
        {
            flowGraphsToShow.Add(args.FlowGraph);
            incrementalGraphsToShow.Add(args.IncrementalGraph);
        }

    }
}
