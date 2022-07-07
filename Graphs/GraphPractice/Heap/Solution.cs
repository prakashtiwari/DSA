using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.Heap
{
    public class Solution
    {
        public List<int> Solve(List<int> A, int B)
        {
            int k = B;
            PriorityQueue<Pair> queue = new PriorityQueue<Pair>(true);
            Dictionary<int, int> nxt = new Dictionary<int, int>();
            for (int i = A.Count - 1; i > 0; i--)
            {
                nxt[A[i]] = A[i - 1];
            }
            double last = (double)A[A.Count - 1];
            double d;
            nxt[1] = 0;
            for (int i = 0; i < A.Count; i++)
            {
                d = (double)1.0 * A[i] / last;
                queue.Enqueue(d, new Pair(A[i], (int)last));
            }
            while (queue.Count > 0 && k > 0)
            {
                k--;
                if (k == 0)
                    break;
                Pair p = queue.Dequeue();
                if (nxt.ContainsKey(p.second) == true && nxt[p.second] != 0)
                {
                    p.second = nxt[p.second];
                    d = (double)p.first /(double) p.second;
                    queue.Enqueue(d, new Pair(p.first, p.second));
                }
            }
            List<int> list = new List<int>();
            list.Add(queue.Top().first);
            list.Add(queue.Top().second);
            return list;
        }
    }
}
