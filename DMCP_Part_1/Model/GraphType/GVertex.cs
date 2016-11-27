using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphX;
using GraphX.PCL.Common.Models;

namespace DMCP_Part_1
{

    public class GVertex : VertexBase
    {
        
        public GVertex(int id)
        {
            ID = id;
        }
        public override string ToString()
        {
            return string.Format("{0}", ID);
        }
    }
}
