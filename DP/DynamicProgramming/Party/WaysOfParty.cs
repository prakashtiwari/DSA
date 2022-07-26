using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Party
{
    public class WaysOfParty
    {
        int[] waysparty;
        public int solve(int A)
        {
            waysparty = new int[A + 1];          

            return GetNoOfWaysParty(A);
        }
        public int GetNoOfWaysParty(int n)
        {
            if (n == 1|| n == 2)
                return n;           
            
            if (waysparty[n] != 0)
                return waysparty[n];            
                waysparty[n] = (1*GetNoOfWaysParty(n - 1) + (n - 1) * GetNoOfWaysParty(n - 2))%10003;          
            return waysparty[n];
        }
        //If A is alone, he can party in only 1 way.
        //If A and B are present, A and B both party alone then they can party together.
    }
}
