using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.Heap
{
    public class Pair
    {
        public int first;
        public int second;
        public Pair(int s, int e)
        {
            first = s;
            second = e;
        }
    }
    public class COMP : IComparer<Pair>
    {
        public int Compare(Pair x, Pair y)
        {
            int i = x.first.CompareTo(y.second);
            if (i == 0)
            {
                i = x.second.CompareTo(y.second);
            }
            return i;
        }


    }
}
