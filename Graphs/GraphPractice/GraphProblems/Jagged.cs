using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class Jagged
    {

        public void JaggedPractice()
        {
            int[][] jarr = new int[3][];
            for (int i = 0; i < jarr.Length; i++)
            {
                //Initialize each row
                jarr[i] = new int[4];
                Console.Write("\n Row is lenght is:"+ i);
                for (int j = 0;j< jarr[i].Length; j++)
                {
                    jarr[i][j] = j;
                    Console.Write("\n Jagged data is"+jarr[i][j]);
                
                }
            
            }
        
        }
    }
}
