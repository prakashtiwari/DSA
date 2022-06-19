using System;
using System.Collections.Generic;
using GraphPractice.GraphProblems;
namespace GraphPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InAndOutDegree inAndOutDegree = new InAndOutDegree();
            List<List<int>> adjacency = new List<List<int>>();
            List<int> adj1 = new List<int>();
            //0
            adj1.Add(1);
            adj1.Add(2);           
            adjacency.Add(adj1);          
            //1
            adj1 = new List<int>();
            adj1.Add(3);
            adjacency.Add(adj1);

            //2
            adj1 = new List<int>();
            adj1.Add(0);
            adj1.Add(5);
            adj1.Add(6);
            adjacency.Add(adj1);
            //3
            adj1 = new List<int>();
            adj1.Add(1);
            adj1.Add(4);
            adjacency.Add(adj1);
            //4
            adj1 = new List<int>();
            adj1.Add(2);
            adj1.Add(3);
            adjacency.Add(adj1);

            adj1 = new List<int>();
            adj1.Add(6);
            adj1.Add(4);
            adjacency.Add(adj1);

            adj1 = new List<int>();
            adj1.Add(5);           
            adjacency.Add(adj1);

            inAndOutDegree.FindIndegree(adjacency,adjacency.Count);

            //AlienDictionary alDict = new AlienDictionary();
            //string[] str = new string[] { "wrt", "wrf", "er", "ett", "rftt" };
            //Console.WriteLine("Word order is: "+alDict.AlienOrder(str));
            //PerformBFS();
            //LongestConsequitiveSequence seq = new LongestConsequitiveSequence();
            //seq.GetLongestConsequitiveSequence(new int[] { 2, 5, 7, 10, 11, 12, 13 });
            //Jagged j = new Jagged();
            //j.JaggedPractice();
            //DFS dFS = new DFS(4);
            //dFS.AddEdges(1, 2);
            //dFS.AddEdges(1, 4);
            //dFS.AddEdges(1, 3);
            //dFS.AddEdges(2, 4);
            //dFS.AddEdges(3, 4);
            //dFS.DepthFirst(4, new bool[5]);
            //GraphPractice.GraphProblems.CloneGraph cloneGraph = new CloneGraph();
            //Node node0 = new Node(0);
            //Node node1 = new Node(1);
            //Node node2 = new Node(2);
            //List<Node> list0 = new List<Node>();
            //list0.Add(node1);
            //list0.Add(node2);
            //node0.neighbours = list0;
            //Node clond = cloneGraph.cloneGraph(node0);

            //cloneGraph.cloneGraph()

            //GraphPractice.GraphProblems.Graph grph = new GraphPractice.GraphProblems.Graph(6);
            //grph.BuildUndirectedGraph(1, 2);
            //grph.BuildUndirectedGraph(1, 4);
            //grph.BuildUndirectedGraph(2, 3);
            //grph.BuildUndirectedGraph(2, 6);
            //grph.BuildUndirectedGraph(3, 4);
            //grph.BuildUndirectedGraph(3, 5);
            //grph.BuildUndirectedGraph(5, 6);
            //bool[] visited = new bool[6+1];
            //grph.DFSTraversal(6, visited);
            //BFS();
            //NumberOfIlands();

            //MaxUniqueLength obj = new MaxUniqueLength();
            //Console.Write("Unique Len is" + obj.GetMaxUniqueLength("nigellukewarm"));
            //MergeTree();
            //InheritanceCheck();
            //Console.ReadLine();

            Console.ReadLine();
        }
        static void BFS()
        {
            // Graph graph = new Graph(10);
            //graph.AddEdge(1, 2);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(2, 4);
            //graph.AddEdge(3, 5);
            //graph.AddEdge(5, 6);
            //graph.AddEdge(4, 6);
            //graph.AddEdge(6, 7);
            //graph.AddEdge(7, 8);
            //graph.AddEdge(9, 10);
            //graph.BFSTraversal(4);
            // graph.NodeDistance(4, 3);
            // graph.DFSTraversal(4);
            //graph.SegmentedGraphTraversal(4, 10);
            //Console.WriteLine("Level is " + graph.levelOfTree);


        }
        static void NumberOfIlands()
        {
            NUmberOfIlnds ilands = new NUmberOfIlnds();
            int[,] matrix = new int[,] { { 1, 1, 0, 0, 0 },
                { 0,1,0,0,1},
                {1,0,0,1,1 },
                { 0,0,0,0,0},
                { 1,0,1,0,1}                                            };

            Console.WriteLine("Number of Ilands are: " + ilands.CountIlands(matrix));
        }

        static void PerformBFS()
        {
            BFS obj = new BFS(7);
            obj.AddEdges(1, 3);
            obj.AddEdges(3, 4);
            obj.AddEdges(3, 5);
            obj.AddEdges(4, 2);
            obj.AddEdges(6, 7);
            obj.PerformBFS(3);
            GraphPractice.GraphProblems.DFS dFS = new GraphPractice.GraphProblems.DFS(7);
            dFS.AddEdges(1, 3);
            dFS.AddEdges(3, 4);
            dFS.AddEdges(3, 5);
            dFS.AddEdges(4, 2);
            dFS.AddEdges(6, 7);
            Console.WriteLine("No of components: " + dFS.NomberOfComponent(5));
        }
    }
}
