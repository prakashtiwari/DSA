// See https://aka.ms/new-console-template for more information
using GraphPract.BFS;
using GraphPract.DFS;

Console.WriteLine("Hello, World!");

//List<int>[] adjList = new List<int>[5];
//adjList[0] = new List<int>() { 1, 2,4 };
//adjList[1] = new List<int>() { 0 };
//adjList[2] = new List<int> { 0 };
//adjList[3] = new List<int>() { 4 };
//adjList[4] = new List<int>() { 3 };

//DFSTraversal dFSTraversal = new DFSTraversal(5);

//dFSTraversal.PerformDfsTraversal(0, adjList);
//////////////////Bfs

//BFS bFS = new BFS(10);

//List<int>[] adjMat = new List<int>[10];
//adjMat[0] = new List<int>() { 0 };
//adjMat[1] = new List<int>() { 2, 6 };
//adjMat[2] = new List<int>() { 3, 4 };
//adjMat[3] = new List<int>() { 2 };
//adjMat[4] = new List<int> { 2, 5 };
//adjMat[5] = new List<int>() { 4, 8 };
//adjMat[6] = new List<int>() { 1, 7, 9 };
//adjMat[7] = new List<int>() { 6, 8 };
//adjMat[8] = new List<int>() { 5, 7 };
//adjMat[9] = new List<int>() { 6 };

//List<int> result = bFS.BFSTraversal(1, adjMat);

//result.Count();

Graph graph = new Graph(5);


graph.AddEdges(1,0);
graph.AddEdges(2,1);
graph.AddEdges(3,4);
int connectedCount = graph.GetProvinceCount();
Console.WriteLine($"Num of connected comp are: {connectedCount}");
Console.ReadLine();
