class Solution
{
    //Depth First Search function to traverse connected provinces
    public void dfs(int i, List<List<int>> M, List<bool> visited)
    {
        visited[i] = true;
        //traverse all the neighbours of the current province
        for (int j = 0; j < visited.Count; j++)
        {
            //if j is not the current province and j is connected to i and j is not visited
            if (i != j && M[i][j] == 1 && !visited[j])
            {
                //recursively call dfs for the connected province
                dfs(j, M, visited);
            }
        }
    }

    //Function to count the number of provinces
    public int numProvinces(List<List<int>> adj, int V)
    {
        //if the adjacency matrix is empty, return 0
        if (adj.Count == 0 || adj[0].Count == 0)
        {
            return 0;
        }
        int n = adj.Count;
        List<bool> visited = new List<bool>(n);
        for (int i = 0; i < n; i++)
        {
            visited.Add(false);
        }
        int ans = 0;
        //traverse all the provinces
        for (int i = 0; i < visited.Count; i++)
        {
            //if the current province is not visited
            //increment the answer and perform dfs to count all the connected provinces
            if (!visited[i])
            {
                dfs(i, adj, visited);
                ans++;
            }
        }
        //return the number of provinces
        return ans;
    }
}