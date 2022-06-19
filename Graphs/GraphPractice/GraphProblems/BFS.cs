using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class BFS
    {
        public int V;
        public List<List<int>> adjList;
        bool[] visited;
        public BFS(int v)
        {
            V = v + 1;
            adjList = new List<List<int>>(V);
            visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                adjList.Add(new List<int>());
                visited[i] = false;

            }

        }
        public void AddEdges(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        public void PerformBFS(int source)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            while (queue.Count > 0)
            {
                int item = (int)queue.Dequeue();
                List<int> items = adjList[item];
                for (int i = 0; i < items.Count; i++)
                {
                    if (!visited[i])
                    {
                        Console.WriteLine("BFS nodes are:" + items[i]);
                        queue.Enqueue(items[i]);
                        visited[i] = true;
                    }
                }

            }

        }
    }
}
