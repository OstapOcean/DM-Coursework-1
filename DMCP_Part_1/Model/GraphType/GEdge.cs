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
        
        private int _value;
        public int Value
        {
            get { return _value; }
        }
 
       
        public GEdge(GVertex source, GVertex target, int value)
            : base(source, target)
        {
            _value = value;
            Weight = 111;
        }
        string _text;
        public string Text
        {
            get { 
                return String.Format("{0}", 
                    Value == 9999 ?"\u221E" :Value.ToString()
                    ); }
            set { _text = value; }
        }
        public override string ToString()
        {
            return Text;
        }
        
    }
}
