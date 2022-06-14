using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    public class Graph
    {
        //Number of vertices
        private int _V;
        public int levelOfTree = 0;
        public int distanceOfNode;
        bool[] visited;
        private LinkedList<int>[] adjList;

        public Graph(int V)
        {

            _V = V + 1;
            visited = new bool[_V];
            adjList = new LinkedList<int>[_V];
            for (int i = 0; i < _V; i++)
            {
                adjList[i] = new LinkedList<int>();
                visited[i] = false;

            }
        }
        public void AddEdge(int v, int w)
        {
            adjList[v].AddLast(w);
            adjList[w].AddLast(v);

        }
        public void BFSTraversal(int source)
        {
            bool[] visited = new bool[_V];
            int[] distance = new int[_V];
            for (int i = 0; i < _V; i++)
            {
                visited[i] = false;
            }
            Queue<int> queue = new Queue<int>();
            visited[source] = true;
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                levelOfTree++;
                source = queue.Dequeue();
                Console.WriteLine("Visited node is:" + source);
                LinkedList<int> list = adjList[source];
                foreach (var value in list)
                {
                    if (!(visited[value]))
                    {
                        queue.Enqueue(value);
                        visited[value] = true;

                    }
                }

            }

        }

        public int NodeDistance(int source, int destination)
        {
            bool[] visited = new bool[_V];
            int[] distance = new int[_V];
            for (int i = 0; i < _V; i++)
            {
                visited[i] = false;
            }
            Queue<int> queue = new Queue<int>();
            visited[source] = true;
            distance[source] = 0;
            queue.Enqueue(source);
            while (queue.Count > 0)
            {

                source = queue.Dequeue();
                Console.WriteLine("Visited node is:" + source);
                //Get all the adjacent node from the source and try to visit.
                LinkedList<int> list = adjList[source];
                foreach (var value in list)
                {
                    if (!(visited[value]))
                    {
                        distance[value] = distance[source] + 1;
                        queue.Enqueue(value);
                        visited[value] = true;
                        Console.WriteLine("Distance is " + distance[value] + "Source is " + source + " Node is" + value);

                    }
                }

            }
            distanceOfNode = distance[destination];
            Console.WriteLine("Distance of node is:" + distanceOfNode);
            return distanceOfNode;

        }

        public void DFS(int v, bool[] visited)
        {

            visited[v] = true;
            Console.WriteLine("Visited node is " + v);
            LinkedList<int> ts = adjList[v];
            foreach (int i in ts)
            {
                if (!visited[i])
                {
                    DFS(i, visited);
                }
            }
        }
       
        public void DFSTraversal(int v)
        {
            
            for (int i = 0; i < _V; i++)
            {
                visited[i] = false;
            }
            DFS(v, visited);


        }
        public void SegmentedGraphTraversal(int source, int numberOfNodes)
        {
           
            for (int i = 1; i <= numberOfNodes; i++)
            {
                if (!visited[i])
                {
                    DFS(i,visited);
                }
            }


        }

    }
}
