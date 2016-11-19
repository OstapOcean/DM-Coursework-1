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
        private int _cost;
        public int Cost
        {
            get { return _cost; }
        }
        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
        }
        public GEdge(GVertex source, GVertex target,int capacity, int cost,int id)
            : base(source, target)
        {
            _cost = cost;
            _capacity = capacity;
            ID = id;
        }
        public GEdge(GVertex source, GVertex target, int capacity, int cost)
            : base(source, target)
        {
            _cost = cost;
            _capacity = capacity;
        }
        string _text;
        public string Text
        {
            get { return String.Format("{0}/{1}", Cost, Capacity); }
            set { _text = value; }
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
