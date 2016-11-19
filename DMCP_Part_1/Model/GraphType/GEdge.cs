using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using System.Diagnostics;


namespace DMCP_Part_1
{
    [DebuggerDisplay("{Cost}/{Capacity}")]
    public class GEdge:Edge<GVertex>
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
        public GEdge(GVertex source, GVertex target,int capacity, int cost)
            : base(source, target)
        {
            _cost = cost;
            _capacity = capacity;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}",Cost,Capacity );
        }
    }
}
