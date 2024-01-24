using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPract.DFS
{
    public class DFSTraversal
    {
        List<List<int>> adjList = new List<System.Collections.Generic.List<int>>();
        int totalNodes = 0;
        bool[] visited;
        public DFSTraversal(int totalNode)
        {
            totalNodes = totalNode;
            visited = new bool[totalNodes];
            for (int i = 0; i < totalNodes; i++)
            {
                visited[i] = false;
            }
        }

        public void PerformDfsTraversal(int start, List<int>[] adjList)
        {
            List<int> result = new List<int>();
            DFS(start, visited, adjList, result);

        }
        private void DFS(int start, bool[] visited, List<int>[] adjList, List<int> result)
        {
          
            result.Add(start);
            visited[start] = true;
            List<int> node = adjList[start];
            foreach (int i in node)
            {
                if (!visited[i])
                {
                    DFS(i, visited, adjList, result);
                }
            }

        }
    }
}
