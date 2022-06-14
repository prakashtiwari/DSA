using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class Graph
    {
        public int Nodes;
        List<List<int>> adjList;

        public Graph(int nodes)
        {
            Nodes = nodes + 1;
            adjList = new List<List<int>>(Nodes);
            for (int i = 0; i < Nodes; i++)
            {
                adjList.Add(new List<int>());

            }

        }
        public void BuildUndirectedGraph(int node, int edge)
        {

            adjList[node].Add(edge);
            adjList[edge].Add(node);
        }

        public void DFSTraversal(int start, bool[] visited)
        {
            visited[start] = true;
            Console.WriteLine("VisitedNode is:" + start);
            List<int> adj = adjList[start];
            foreach (var node in adj)
            {

                if (!visited[node])
                {
                    DFSTraversal(node,visited);


                }
            }
          
        }


    }
}
