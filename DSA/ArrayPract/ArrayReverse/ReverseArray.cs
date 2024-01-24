using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPract.ArrayReverse
{
    public class ReverseArray
    {
        public int[] Reverse(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            int temp = 0;
            while (l < r)
            {
                temp = arr[r];
                arr[r] = arr[l];
                arr[l] = temp;
                l++;
                r--;
            }
            return arr;
        }
    }
}
