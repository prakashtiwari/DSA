using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPract.LongestStrUniqueChar
{
    public class LongestStringUniqChar
    {
        public int GetLongest(string input)
        {

            int longestLen = 0;
            if (string.IsNullOrEmpty(input))
                return longestLen;
            int start = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (map.ContainsKey(input[i]))
                {
                    start = map[input[i]] + 1;//If char already in the map, next start will be index of the char+1
                    map[input[i]] = i;


                }
                else
                {
                    map.Add(input[i], i);
                }
                if (longestLen < i - start + 1)
                    longestLen = i - start + 1;
            }
            return longestLen;
        }
    }
}
