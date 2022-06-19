using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class ValidTree
    {
        public bool IsValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1)
                return false;
            UnionFindDS union = new UnionFindDS(n);
            foreach (var edge in edges)
            {
               if(!union.Union(edge[0], edge[1]))
                {
                    return false;

                }
            
            }
            return true;

        }
    }

    public class UnionFindDS
    {
        int[] root;
        int[] rank;
        int[] size;
        public UnionFindDS(int nodeCount)
        {
            root = new int[nodeCount];
            rank = new int[nodeCount];
            size = new int[nodeCount];
            for (int node = 0; node < nodeCount; node++)
            {
                root[node] = node;
                rank[node] = 1;
                size[node] = 1;

            }

        }
        public int FindRoot(int x)
        {
            if (x == root[x])
                return x;
            root[x] = FindRoot(root[x]);
            return root[x];

        }
        public bool Union(int nodeA, int nodeB)
        {

            int rootA = FindRoot(nodeA);
            int rootB = FindRoot(nodeB);
            if (rootA != rootB)
            {
                if (rank[rootA] > rank[rootB])
                {
                    root[rootB] = rootA;
                    size[rootA] += size[rootB];

                }
                else if (rank[rootB] > rank[rootB])
                {
                    root[rootA] = rootB;
                    size[rootB] += size[rootA];
                }
                else
                {
                    root[rootB] = rootA;
                    rank[rootA]++;
                    size[rootA]++;
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        }
    }
