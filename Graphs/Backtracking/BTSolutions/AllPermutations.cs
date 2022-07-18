using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking.BTSolutions
{
    public class AllPermutations
    {

        public void GetAllPermutations(int[] arr, int index, int n, IList<IList<int>> result)
        {
            if (index == n)
            {
                Print(arr, "Adding to result! " + index);
                result.Add((IList<int>)arr.Clone());

                return;
            }
            int l = 0;
            for (l = index; l < arr.Length; l++)
            {
                // Print(arr,"Preorder: Before swap "+index+ " l is "+l);
                Swap(arr, l, index);
                Print(arr, "Preorder: After swap index=" + index + " l=" + l);
                GetAllPermutations(arr, index + 1, n, result);
                Print(arr, "Postorder  swap back to orig index=" + index + " l=" + l);
                Swap(arr, l, index);
                // Print(arr, "Post after swap back to orig index=" +index + " l="+l);

            }

        }
        private void Swap(int[] arr, int l, int r)
        {
            int temp = arr[l];
            arr[l] = arr[r];
            arr[r] = temp;

        }
        private void Print(int[] arr, string order)
        {
            string s = "";
            for (int x = 0; x < arr.Length; x++)
            {
                s = s + " " + arr[x];
            }
            Console.WriteLine("Permu " + order + " " + s + "\n");

        }
    }
}
