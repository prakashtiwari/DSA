using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class DFS
    {

        List<List<int>> adjacencyList;

        int Vertices;
        //bool[] visisted;

        public DFS(int numberOfNodes)
        {
          //  visisted = new bool[this.Vertices];
            this.Vertices = numberOfNodes + 1;
            adjacencyList = new List<List<int>>(numberOfNodes+1);
            for (int i = 0; i < Vertices; i++)
            {

                adjacencyList.Add(new List<int>());
               
            }
          
        
        }
        //Undirected graph
        public void AddEdges(int u, int v)
        {
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }
       
        public void DepthFirst(int source,bool [] visisted)
        {
            visisted[source] = true;
            Console.WriteLine("Visited node is :"+ source);
            List<int> neighbours = adjacencyList[source];
            for (int i = 0; i < neighbours.Count; i++)
            {
               if(!visisted[neighbours[i]])
                {
                  //  visisted[neighbours[i]] = true;
                    DepthFirst(neighbours[i], visisted);

                }
            
            }
        
        }

    }
}
