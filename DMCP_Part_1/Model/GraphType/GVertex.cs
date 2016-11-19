using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DMCP_Part_1
{
    [DebuggerDisplay("{ID}")]

    public class GVertex{
        private int _id;
        public int ID
        {
            get { return _id; }
        }
        public GVertex(int id)
        {
            _id = id;
        }
        public override string ToString()
        {
            return string.Format("{0}", ID);
        }
    }
}
