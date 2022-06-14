using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class PacificAtlantic
    {
        public IList<IList<int>> GetPacificAtlantic(int[][] heights)
        {
            IList<IList<int>> answer = new List<IList<int>>();
            int row = heights.Length;
            if (row == 0)
                return answer;// If grid is empty then return.



            bool[][] pacificOcean = new bool[heights.Length][];
            bool[][] atlanticOcean = new bool[heights.Length][];
            for (int i = 0; i < row; i++)
            {
                pacificOcean[i] = new bool[heights.Length];
                atlanticOcean[i] = new bool[heights.Length];
                for (int j = 0; j < pacificOcean[i].Length; j++)
                {
                    pacificOcean[i][j] = false;
                    pacificOcean[i][j] = false;
                }

            }
            for (int i = 0; i < row; i++)
            {
                DFS(i, 0, heights, pacificOcean);
                DFS(i, heights[i].Length - 1, heights, atlanticOcean);

            }
            for (int i = 0; i < heights[0].Length; i++)
            {
                DFS(0, i, heights, pacificOcean);
                DFS(heights.Length - 1, 0, heights, atlanticOcean);

            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    if (pacificOcean[i][j] && atlanticOcean[i][j])
                    {

                        answer.Add(new List<int> { i, j });
                    }

                }

            }

            return answer;
        }

        public void DFS(int x, int y, int[][] heights, bool[][] reachable)
        {

            int[] row = new int[] { -1, 0, 0, 1 };
            int[] col = new int[] { 0, -1, 1, 0 };
            reachable[x][y] = true;
            for (int i = 0; i < 4; i++)
            {
                if (IsSafe(x + row[i], y + col[i], heights, reachable) && heights[x + row[i]][y + col[i]] >= heights[x][y])
                {
                    DFS(x + row[i], y + col[i], heights, reachable);
                }

            }


        }
        public bool IsSafe(int x, int y, int[][] heights, bool[][] reachable)
        {
            return (x >= 0 && x < heights.Length && y >= 0 && x < heights[y].Length && reachable[x][y]);
        }

    }
}
