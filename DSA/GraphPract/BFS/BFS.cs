using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPract.BFS
{
    public class BFS
    {
        int totalNode;
        bool[] visited;
        public BFS(int nodeCount)
        {
            totalNode = nodeCount;
            visited = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                visited[i] = false;
            }
        }
        public List<int> BFSTraversal(int startNode, List<int>[] adjList)
        {
            List<int> items = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                List<int> adjItems = adjList[node];
                items.Add(node);
                foreach (int item in adjItems)
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
            return items;
        }

    }
}
