using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using GraphX.PCL.Common.Models;


namespace DMCP_Part_1
{
    public class GEdge : EdgeBase<GVertex>
    {
        static public bool includeCost = false;
        private int _flow;
        public int Flow
        {
            get { return _flow; }
        }
        private int _cost;
        public int Cost
        {
            get { return _cost; }
        }
       
        public GEdge(GVertex source, GVertex target, int value,int cost)
            : base(source, target)
        {
            _cost = cost;
            _flow = value;
            Weight = 111;
        }
        string _text;
        public string Text
        {
            get { 
                return String.Format
                    (
                    "{0}", 
                    Flow == 9999 ?
                                    "\u221E" :(Flow.ToString() +
                    (includeCost ?  
                                    (Cost== -1 ? "" :  " / " + Cost.ToString()) : "")
                                             )
                    ); 
            }
            set { _text = value; }
        }
        public override string ToString()
        {
            return Text;
        }
        
    }
}
