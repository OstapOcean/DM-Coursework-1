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
  
    class Visualizer:INotifyPropertyChanged
    {
        private TransportNetwork network;

        private int deltaF;
        public int DeltaFlow { get { return deltaF; } }
        private int currentFlow;
        public int CurrentFlow { get { return currentFlow; } }


        private List<TransportGraph> incrementalGraphraphList;
        public TransportGraph IncrementalGraphToShow
        {
            get
            {
                return incrementalGraphraphList[listIndex];
            }
        }

        private List<TransportGraph> flowGraphraphList; 
        public TransportGraph FlowGraphToShow
        {
            get
            {
                return flowGraphraphList[listIndex];
            }
        }
        private int listIndex = 0;
        public void LastIndex()
        {
            listIndex = flowGraphraphList.Count - 1;
        }
        public void IncGraphListIndex()
        {
            if (listIndex + 1 < flowGraphraphList.Count) {
                listIndex = listIndex + 1;
            }
        }
        public void DecGgraphListIndex()
        {
            if (listIndex -1  >=0 )
            {
                listIndex = listIndex - 1;
            }
        }

        public Visualizer()
        {
            flowGraphraphList = new List<TransportGraph>();
            incrementalGraphraphList = new List<TransportGraph>();
            int q =9999;
            int[][] cost ={
                         new int[]{q,0,0,0,q,q,q,q,q},
                         new int[]{q,q,q,q,10,11,18,32,q},
                         new int[]{q,q,q,q,16,14,20,25,q},
                         new int[]{q,q,q,q,26,28,22,30,q},
                         new int[]{q,q,q,q,q,q,q,q,0},
                         new int[]{q,q,q,q,q,q,q,q,0},
                         new int[]{q,q,q,q,q,q,q,q,0},
                         new int[]{q,q,q,q,q,q,q,q,0},
                         new int[]{q,q,q,q,q,q,q,q,q}
            };
              int[][] capacity ={
                         new int[]{0,41,50,89,0,0,0,0,0},
                         new int[]{0,0,0,0,q,q,q,q,0},
                         new int[]{0,0,0,0,q,q,q,q,0},
                         new int[]{0,0,0,0,q,q,q,q,0},
                         new int[]{0,0,0,0,0,0,0,0,44},
                         new int[]{0,0,0,0,0,0,0,0,33},
                         new int[]{0,0,0,0,0,0,0,0,71},
                         new int[]{0,0,0,0,0,0,0,0,10},
                         new int[]{0,0,0,0,0,0,0,0,0}
            };
            network=new TransportNetwork(capacity,cost);
            network.IntermediateTransportNetResult += new IntermediateGraphDelegate(Catcher);
            network.FlowMinCost(158);
        }

        private void Catcher(object sender, IntermediateTransportNetEventArgs args)
        {
            flowGraphraphList.Add(args.FlowGraph);
            incrementalGraphraphList.Add(args.IncrementalGraph);
            deltaF=args.deltaF;
            currentFlow = args.currentFlow;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
