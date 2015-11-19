using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    class Node<T>
    {
        private const string NODE_STYLE = "{0}",
            EMPTY_NODE = "[,.phantom]";

        public T Data
        {
            get;
            private set;
        }

        public Node<T> LeftChild
        {
            get;
            set;
        }

        public Node<T> RightChild
        {
            get;
            set;
        }

        public int Height
        {
            get
            {
                int left = HeightOrDefault(LeftChild),
                    right = HeightOrDefault(RightChild);
                
                return (int)Math.Max(left, right) + 1;
            }
        }

        public Node(T data)
        {
            Data = data;
        }

        public static int HeightOrDefault(Node<T> node)
        {
            if (node != null)
            {
                return node.Height;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string left = EMPTY_NODE,
                right = EMPTY_NODE;

            if (LeftChild != null)
            {
                left = LeftChild.ToString();
            }

            if (RightChild != null)
            {
                right = RightChild.ToString();
            }

            return string.Format("[{0} {1} {2} ]", string.Format(NODE_STYLE, Data), left, right);
        }

        public List<T> ToList()
        {
            var list = new List<T>();

            if (LeftChild != null)
            {
                list.AddRange(LeftChild.ToList());
            }

            list.Add(Data);

            if (RightChild != null)
            {
                list.AddRange(RightChild.ToList());
            }

            return list;
        }
    }
}
