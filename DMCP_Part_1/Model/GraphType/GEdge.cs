using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace DMCP_Part_1
{
    public class GEdge:Edge<GVertex>,ITagged<string>
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
        

        public string Tag
        {
            get
            {
                return string.Format("{0}/{1}", Cost, Capacity);
            }
            set
            {

            }
        }

        public event EventHandler TagChanged;
    }
}
