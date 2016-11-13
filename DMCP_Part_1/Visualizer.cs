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
        private BidirectionalGraph<GVertex, GEdge> graphToShow;
        public BidirectionalGraph<GVertex, GEdge> GraphToShow
        {
            get
            {
                return graphToShow;
            }
        }

        public Visualizer()
        {
            GVertex V = new GVertex(1);
            graphToShow = new BidirectionalGraph<GVertex,GEdge>();
            graphToShow.AddVertex(V);
        }



        public event PropertyChangedEventHandler PropertyChanged;

    }
}
