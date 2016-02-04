using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode a = new GraphNode(),
                b = new GraphNode(),
                c = new GraphNode(),
                d = new GraphNode(),
                e = new GraphNode(),
                f = new GraphNode(),
                g = new GraphNode(),
                h = new GraphNode(),
                i = new GraphNode();

            Graph graph = new Graph(new GraphNode[] { a, b, c, d, e, f, g, h, i });

            graph.Connect(a, new GraphNode[] { b, c, g });
            graph.Connect(b, new GraphNode[] { d });
            graph.Connect(c, new GraphNode[] { a, d, e });
            graph.Connect(d, new GraphNode[] { g });
            graph.Connect(e, new GraphNode[] { a, f, i });
            graph.Connect(f, new GraphNode[] { c, d, e, h });
            graph.Connect(g, new GraphNode[] { h });
            graph.Connect(h, new GraphNode[] { d, i });
            graph.Connect(i, new GraphNode[] { f });

            Console.WriteLine(graph);

            Console.WriteLine("Tiefensuche:  " + string.Join(", ", graph.DeepSearch(a)));
            Console.WriteLine("Breitensuche: " + string.Join(", ", graph.BroadSearch(a)));
        }
    }
}
