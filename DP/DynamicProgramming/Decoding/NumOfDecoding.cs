using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Decoding
{
    public class NumOfDecoding
    {
        int mod = (int)Math.Pow(10, 5) + 7;
        public int numDecodings(string A)
        {
          
            int len = string.IsNullOrEmpty(A) ? 0 : A.Length;
            int[] dpArr = new int[len + 1];
            return Iterative(A,dpArr);
        }
        private int Iterative(string A, int[] vs)
        {
            //Base cases
            //WHen string is empty.
            int len = string.IsNullOrEmpty(A) ? 0 : A.Length;
            vs[0] = 1;
            //When string has only one character, there is only one way to decode.
            vs[1] = 1;
            for(int i=2;i<=len;i++)
            {
                //Get least significant bit.
                int singleCharacter =int.Parse(A.Substring(len - 1, 1));
                Console.WriteLine("Single Char is:" + A.Substring(len - 1, 1));
                int doubleCharacter= int.Parse(A.Substring(len - 2, 2));
                Console.WriteLine("Char is:" + A.Substring(len - 2, 2));
                if (singleCharacter >=0 && singleCharacter <= 9)
                {
                    vs[i] = (vs[i] + vs[i - 1]) % mod;
                }
                if (doubleCharacter > 9 && doubleCharacter <= 26)
                {
                    vs[i] = (vs[i] + vs[i - 2]) % mod;
                }


            }
            return vs[A.Length] % mod;

        }

    }
}
