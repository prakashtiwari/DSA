using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class NUmberOfIlnds
    {
        //

        int Row=5; int Col=5;

        bool IsSafe(int[,] M, int row, int col, bool[,] visited)
        {

            return (row >= 0 && row < Row && col >= 0 && col < Col && visited[row, col]);
        
        }

        public void DFS(int[,] M, int row, int column, bool[,] visited)
        {
            int[] rowNumber = {-1,-1,-1,0,0,1,1,1};
            int [] columnNum ={-1,0,1,-1,1,-1,0,1};


            visited[row, Col] = true;

            for (int k = 0; k < 8; ++k)
            {
                if (IsSafe(M, row + rowNumber[k], column + columnNum[k], visited))
                {
                    DFS(M, row + rowNumber[k], column + columnNum[k], visited);
                }
            }
        }
        public int CountIlands(int [,] M)
        {

            bool[,] visited = new bool[Row,Col];
            int count = 0;
            for (int i = 0; i < Row; ++i)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (M[i, j] == 1 && !visited[i, j])
                    {
                        DFS(M, i, j, visited);
                        count += 1;
                    }
                
                }
            
            }
            return count;
        }

    }
}
