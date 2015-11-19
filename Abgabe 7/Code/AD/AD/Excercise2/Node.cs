using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class Node
    {
        private const string NODE_STYLE = "{}, draw , circle",
            EMPTY_NODE = "[,.phantom]";

        public Node Left
        {
            get;
            set;
        }

        public Node Right
        {
            get;
            set;
        }

        public Node Clone()
        {
            var node = new Node();

            node.Left = Left;
            node.Right = Right;

            return node;
        }

        public override string ToString()
        {
            string left = EMPTY_NODE,
                right = EMPTY_NODE;

            if (Left != null)
            {
                left = Left.ToString();
            }

            if (Right != null)
            {
                right = Right.ToString();
            }

            return string.Format("[{0} {1} {2} ]", NODE_STYLE, left, right);
        }
    }
}
