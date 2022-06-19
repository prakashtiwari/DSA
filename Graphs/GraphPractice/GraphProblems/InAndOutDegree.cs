using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class InAndOutDegree
    {

        public void FindIndegree(List<List<int>> adjList, int n)
        {
            int[] indeg = new int[n];
            int[] outDeg = new int[n];
            for (int i = 0; i < n; i++)
            {
                List<int> deg = adjList[i];
                outDeg[i] = deg.Count;
                for (int j = 0; j < deg.Count; j++)
                {
                    indeg[deg[j]]++;
                
                }
            
            }

            for (int k = 0; k < n; k++)
            {
                Console.WriteLine("Indegree is:"+indeg[k]+"Out degree:"+outDeg[k]);
            }

        }
    }
}
