using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking.BTSolutions
{
    public class AllSubsets
    {

        public List<List<int>> GetAllSubset(List<int> A)
        {
            if (A == null)
                return null;
            A.OrderBy(p=>p);
            List<List<int>> result = new List<List<int>>();
            GetAllSubset(A, 0, new List<int>(), result);
           // Print(result);
            return result;
        }
        private void GetAllSubset(List<int> input, int index, List<int>
            intermediate, List<List<int>> result)
        {
            if (index >= input.Count)
            {
                Console.WriteLine("Index is while adding to result:" + index);
                result.Add(new List<int>(intermediate));
                if (intermediate.Count == 0)
                {
                    Console.WriteLine("Base condition met: Adding blank to the result");
                }
                else
                {
                    intermediate.ForEach(delegate (int i)
                    {
                        Console.WriteLine("Base condition met: Adding to result values: " + i);
                    });
                }
                return;
            }
            Console.WriteLine("When not choosing Index:" + index);            
            //Not pick element
            GetAllSubset(input, index + 1, intermediate, result);
            //Pick element
            intermediate.Add(input[index]);
            Console.WriteLine("When choosing the element index is:" + index + " Adding element : " + input[index]);
            GetAllSubset(input, index + 1, intermediate, result);
            Console.WriteLine("Post BT: Index:" + index);
            Console.WriteLine("Post BT: Removed element:" + intermediate[intermediate.Count - 1]);
            intermediate.RemoveAt(intermediate.Count - 1);


        }
        private void Print(IList<IList<int>> lists)
        {
            string s = "";
            foreach (List<int> res in lists)
            {
                res.ForEach(delegate (int i)
                {
                    Console.WriteLine("Value is " + i);

                });

                Console.WriteLine("\n");
            }
        }
        //public IList<IList<int>> Subsets(int[] nums)
        //{
        //    IList<IList<int>> ans = new List<IList<int>>();

        //    if (nums == null || nums.Length == 0)
        //        return ans;

        //    List<int> output = new List<int>();
        //    int index = 0;
        //    Solve(nums, output, index, ans);
        //    return ans;

        //}

        public void Solve(int[] nums, List<int> output, int index,
                                        List<List<int>> ans)
        {
            if (index >= nums.Length)
            {
                ans.Add(new List<int>(output));
                return;
            }

            // At every index we have 2 choices, take it or not take it.

            // Not take the element at the current index.
            Solve(nums, output, index + 1, ans);

            // Take the element at the current index.
            output.Add(nums[index]);
            Solve(nums, output, index + 1, ans);

            // Remove the element from the list.
            output.RemoveAt(output.Count - 1);
        }
    }
}
