using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice.ProbAndSolution
{
   public class ReverseString
    {
        public string GetReverseString(string s)
        {
            string op = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    op += s[i];
                }

            }
            return op;
        }
    }
}
