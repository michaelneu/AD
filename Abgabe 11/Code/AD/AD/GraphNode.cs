using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    class GraphNode
    {
        public enum NodeColor { WHITE, GREY, BLACK };

        private static int index = 0;

        public int Index
        {
            get;
            private set;
        }

        public string Name
        {
            get
            {
                return Index.ToString();
            }
        }

        public NodeColor Color
        {
            get;
            set;
        }

        public GraphNode Previous
        {
            get;
            set;
        }

        public int Distance
        {
            get;
            set;
        }

        public GraphNode()
        {
            Index = index++;

            Color = GraphNode.NodeColor.WHITE;
            Distance = int.MaxValue;
        }

        public override string ToString()
        {
            return Name + "";
        }
    }
}
