using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySolution.NextGreater
{
    public class NextGreaterElementInArray
    {
        public int[] GetNextGreaterElement(int[] elements)
        {

            int n = elements.Length;
            int[] nextGreater = new int[n];
            Stack<int> stk = new Stack<int>();

            //Getting the next greater element from right to left.
            for (int i = n - 1; i >= 0; i--)
            {
                //If stack containing the smaller or equal elements, should be popped 
                while (stk.Count > 0 && stk.Peek() <= elements[i % n])
                {
                    stk.Pop();
                }
                if (i < n)
                {
                    if (stk.Count > 0)
                    {
                        nextGreater[i] = stk.Peek();
                        Console.WriteLine($"Element pushed is {i} alue is  : {elements[i % n]}  next great is:  " + stk.Peek());
                    }
                    else
                    {
                        //If last element, the put -1;
                        nextGreater[i] = -1;
                    }

                }
                //Console.WriteLine("Element pushed in stack" + elements[i % n]);
                stk.Push(elements[i % n]);
            }
            int[] response = nextGreater.Reverse().ToArray();
            for (int i = 0; i < response.Length; i++)
            {
                Console.WriteLine($"Element is {i}  Next greater is:" + nextGreater[i]);
            }
            return response;
        }
        public void GetPerviousSmallerElement(int[] elements)
        {

            int size = elements.Length;
            int[] previousMin = new int[size];
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < size; i++)
            {
                while (stk.Count > 0 && stk.Peek() >= elements[i])
                {
                    stk.Pop();

                }
                if (i < size)
                {
                    if (stk.Count > 0)
                    {
                        previousMin[i] = stk.Peek();
                    }
                    else
                    {
                        previousMin[i] = 0;
                    }
                }
                stk.Push(elements[i]);

            }

        }

    }
}
