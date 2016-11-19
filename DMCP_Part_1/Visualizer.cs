using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using QuickGraph;

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
            GVertex V = new GVertex(1);
            GVertex A = new GVertex(2);

            graphToShow = new TransportGraph(1,1);
            graphToShow.AddVertex(V);
            graphToShow.AddVertex(A);
            GEdge E = new GEdge(V, A, 1, 1);
            GEdge R = new GEdge(A, V, 2, 2);

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
