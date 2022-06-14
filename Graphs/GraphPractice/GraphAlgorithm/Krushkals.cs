using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphAlgorithm
{
    public class Graph
    {

        public int Vert;
        public int Edg;

        public class Edge : IComparable<Edge>
        {

            public int src, dest, weight;
            public int CompareTo(Edge other)
            {
                return this.weight - other.weight;
            }
        }
        /// <summary>
        /// This is parent array.
        /// </summary>
        public class Subset
        {
            public int parent, rank;

        }

        public Edge[] edges;

        public Graph(int v, int e)
        {
            Vert = v;
            Edg = e;
            edges = new Edge[e];
            for (int i = 0; i < e; i++)
            {
                edges[i] = new Edge();

            }
        }
        /// <summary>
        /// Connect each child node to root
        /// </summary>
        /// <param name="subsets"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        int findRoot(Subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
            {
                subsets[i].parent = findRoot(subsets, i);

            }
            return subsets[i].parent;

        }
        void Union(Subset[] subsets, int x, int y)
        {
            int xroot = findRoot(subsets, x);
            int yroot = findRoot(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;

            }

        }
        void KruskalMST()
        {
            Edge[] resultedge = new Edge[Vert];
            int e = 0;
            int i;
            for (i = 0; i < Vert; ++i)
            {
                resultedge[i] = new Edge();
            }
          //  Array.Sort(edges);
            Subset[] subset = new Subset[Vert];
            for (i = 0; i < Vert; i++)
            {
                subset[i] = new Subset();
            }
            for (int v = 0; v < Vert; Vert++)
            {

                subset[v].parent = v;
                subset[v].rank = 0;
            }
            i = 0;
            while (e < Vert - 1)
            {
                Edge next = new Edge();
                next = edges[i++];
                int x = findRoot(subset, next.src);
                int y = findRoot(subset, next.dest);
                if (x != y)
                { 
                }

            }
        }
    }
}
