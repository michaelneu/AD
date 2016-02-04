using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    class Graph
    {
        private AdjacencyMatrix matrix;
        private GraphNode[] nodes;

        public Graph(GraphNode[] nodeList)
        {
            matrix = new AdjacencyMatrix(nodeList.Length);
            nodes = nodeList;
        }

        public void Connect(GraphNode a, GraphNode[] targets)
        {
            foreach (var item in targets)
            {
                Connect(a, item);
            }
        }

        public void Connect(GraphNode a, GraphNode b)
        {
            matrix[a, b] = 1;
        }

        private List<GraphNode> GetConnectedNodes(GraphNode node)
        {
            var connected = new List<GraphNode>();

            for (int i = 0; i < nodes.Length; i++)
            {
                var target = nodes[i];

                if (matrix[node, target] != 0)
                {
                    connected.Add(target);
                }
            }

            return connected;
        }

        public List<GraphNode> DeepSearch(GraphNode start)
        {
            foreach (var item in nodes)
            {
                item.Color = GraphNode.NodeColor.WHITE;
                item.Previous = null;
            }

            return DeepSearchVisit(start).Distinct().ToList();
        }

        private List<GraphNode> DeepSearchVisit(GraphNode start)
        {
            var order = new List<GraphNode>();

            start.Color = GraphNode.NodeColor.GREY;

            foreach (var item in GetConnectedNodes(start))
            {
                if (item.Color == GraphNode.NodeColor.WHITE)
                {
                    item.Previous = start;
                    order.AddRange(DeepSearchVisit(item));
                }

                item.Color = GraphNode.NodeColor.BLACK;

                order.Add(item);
            }

            return order;
        }

        public List<GraphNode> BroadSearch(GraphNode start)
        {
            foreach (var item in nodes)
            {
                item.Color = GraphNode.NodeColor.WHITE;
                item.Distance = int.MaxValue;
                item.Previous = null;
            }

            var order = new List<GraphNode>();

            start.Color = GraphNode.NodeColor.GREY;
            start.Distance = 0;

            var queue = new Queue<GraphNode>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var item in GetConnectedNodes(node))
                {
                    if (item.Color == GraphNode.NodeColor.WHITE)
                    {
                        item.Color = GraphNode.NodeColor.GREY;
                        item.Distance = node.Distance + matrix[node, item];
                        item.Previous = node;

                        queue.Enqueue(item);
                    }
                }

                node.Color = GraphNode.NodeColor.BLACK;
                order.Add(node);
            }

            return order;
        }

        public override string ToString()
        {
            return matrix.ToString();
        }
    }
}
