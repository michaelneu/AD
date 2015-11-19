using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise2
{
    public class AVLTreeFactory
    {
        public static List<Node> GetTrees(int height)
        {
            if (height == 1)
            {
                var list = new List<Node>();

                var node = new Node();
                node.Left = new Node();

                list.Add(node);

                node = new Node();
                node.Right = new Node();

                list.Add(node);

                return list;
            }
            else if (height > 1)
            {
                var list = new List<Node>();

                // $H_r = H - 2, H_l = H - 1$
                var leftChildren = GetTrees(height - 1);
                var rightChildren = GetTrees(height - 2);

                var subtrees = CombineSubtrees(leftChildren, rightChildren);
                list.AddRange(subtrees);

                // $H_r = H - 1, H_l = H - 2$
                // left and right children are inverted --> invert parameters
                subtrees = CombineSubtrees(rightChildren, leftChildren);
                list.AddRange(subtrees);

                return list;
            }
            else
            {
                return new List<Node>() { new Node() };
            }
        }

        private static List<Node> CombineSubtrees(List<Node> leftChildren, List<Node> rightChildren)
        {
            var list = new List<Node>();

            if (leftChildren.Count > 0 && leftChildren.Count > 0)
            {
                foreach (var left in leftChildren)
                {
                    foreach (var right in rightChildren)
                    {
                        var temp = new Node();

                        temp.Left = left;
                        temp.Right = right;

                        list.Add(temp);
                    }
                }
            }
            else if (leftChildren.Count > 0)
            {
                foreach (var left in leftChildren)
                {
                    var temp = new Node();

                    temp.Left = left;

                    list.Add(temp);
                }
            }
            else
            {
                foreach (var right in rightChildren)
                {
                    var temp = new Node();

                    temp.Right = right;

                    list.Add(temp);
                }
            }

            return list;
        }
    }
}
