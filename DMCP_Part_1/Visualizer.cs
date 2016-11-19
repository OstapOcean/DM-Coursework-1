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
  
    class Visualizer : INotifyPropertyChanged
    {
        private TransportGraph graphToShow;
        public TransportGraph GraphToShow
        {
            get
            {
                return graphToShow;
            }
        }
        GArea gg_Area;
        private string layoutAlgorithmType;
        private List<String> layoutAlgorithmTypes = new List<string>();
        public string LayoutAlgorithmType
        {
            get { return layoutAlgorithmType; }
            set
            {
                layoutAlgorithmType = value;
                NotifyPropertyChanged("LayoutAlgorithmType");
            }
        }
        public Visualizer()
        {
            gg_Area = new GArea();
            GVertex V = new GVertex(1);
            GVertex A = new GVertex(2);

            graphToShow = new TransportGraph();
            graphToShow.AddVertex(V);
            graphToShow.AddVertex(A);
            GEdge E = new GEdge(V, A, 1, 1,1);
            GEdge R = new GEdge(A, V, 2, 2,2);

            graphToShow.AddEdge(R);
            graphToShow.AddEdge(E);
            
            layoutAlgorithmTypes.Add("BoundedFR");
            layoutAlgorithmTypes.Add("Circular");
            layoutAlgorithmTypes.Add("CompoundFDP");
            layoutAlgorithmTypes.Add("EfficientSugiyama");
            layoutAlgorithmTypes.Add("FR");
            layoutAlgorithmTypes.Add("ISOM");
            layoutAlgorithmTypes.Add("KK");
            layoutAlgorithmTypes.Add("LinLog");
            layoutAlgorithmTypes.Add("Tree");

            LayoutAlgorithmType = "BoundedFR";

            gg_Area.GenerateGraph(graphToShow);
            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
