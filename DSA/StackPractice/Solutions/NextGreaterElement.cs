using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPractice.Solutions
{
    public class NextGreaterElement
    {
        public int[] GetNextGreaterElement(int[] heights)
        {
            int[] ans = new int[heights.Length];
            Stack<int> nextHeight = new Stack<int>();
        

          

            for (int i = heights.Length-1; i >= 0; i--)
            {

                while (nextHeight.Count() > 0 && nextHeight.Peek() < heights[i])
                {
                    nextHeight.Pop();
                }
                if (nextHeight.Count() == 0)//None in the right side
                {
                    ans[i] = -1;
                }
                else
                {
                    ans[i] = nextHeight.Peek();
                }
                nextHeight.Push(heights[i]);
            }
            return ans;
        }
    }
}
