using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySolution.MissingNextElement
{
    public class FindNextMissingPosInt
    {
        public int GetNextMissing(int[] input)
        {
            int n = input.Length;
            int missingNo = 1;
            bool[] missingInt = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (input[i] > 0 && input[i] <= n)
                {
                    missingInt[input[i] - 1] = true;

                }
            }
            for (int i = 0; i < n; i++)
            {

                if (!missingInt[i])
                {
                    return missingNo = i + 1;

                }
            }
            return n + 1;
        }
        public int GetNextMissingOptimized(int[] input)
        {
            int n = input.Length;
            int missingNum = 0;

            for (int i = 0; i < n; i++)
            {
                if (input[i] <= 0)
                {
                    input[i] = n + 2;

                }

            }
            for (int i = 0; i < n; i++)
            {
                int element = Math.Abs(input[i]);
                if (1 <= element && element <= n)
                {
                    int inx = element - 1;
                    input[inx] = -1 * Math.Abs(input[inx]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (input[i] > 0)
                {
                    missingNum = i + 1;
                    break;
                }
            }
            return missingNum;


        }
    }
}
