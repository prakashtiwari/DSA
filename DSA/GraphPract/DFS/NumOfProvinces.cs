namespace GraphPract.DFS
{
    /// <summary>
    /// Graph implementation
    /// </summary>

    public class Graph
    {
        int V;
        List<List<int>> adjList;
        public Graph(int V)
        {
            this.V = V;
            adjList = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
                adjList.Add(new List<int>());
            }
        }
        public int GetProvinceCount()
        {
            int count = 0;
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                visited[i] = false;

            }
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    count++;
                    DFSTraversal(i, adjList, visited);
                }
            }
            return count;

        }
        public void AddEdges(int source, int dest)
        {
            adjList[source].Add(dest);
            adjList[dest].Add(source);
        }

        public void DFSTraversal(int start, List<List<int>> adjMat, bool[] visted)
        {
            visted[start] = true;
            List<int> item = adjList[start];
            foreach (int i in item)
            {
                if (!visted[i])
                {
                    DFSTraversal(i, adjList, visted);
                }
            }
        }
    }

}
