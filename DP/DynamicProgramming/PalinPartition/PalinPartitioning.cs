using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.PalinPartition
{
    public class PalinPartitioningSol
    {
        public int minCutPalindrome(String s)
        {
            int n, min;
            n = s.Length;

            //cut[i] represents minimum number of cuts from String 0 to i
            int[] cut = new int[n];

            //p[i][j] represents String i to j is a palindrome or not
            bool[,] p = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                min = i;  // Max number of cuts is i for string length i+1
                Console.WriteLine("Min is: " + min);
                for (int j = 0; j <= i; j++)
                {
                    // Why i - j < 3  ?
                    // 1. String of length 1 is always palindrome so no need to check in boolean table
                    // 2. String of length 2 is palindrome if Ci == Cj which is already checked in first part so no need to check again
                    // 3. String of length 3 is palindrome if Ci == Cj which is already checked in first part and Ci+1 and Cj-1 is same character which is always a palindrome

                    // If String length >=3
                    // then check if Ci == Cj and if they are equal check if String[j+1 .. i-1] is a palindrome from the boolean table
                    //i - j < 3: This condition is for string "cbc","bb","b": These are palindrome if first character and last character is same.
                    //If string is Palindrome: p[j + 1, i - 1]
                    if (s[j] == s[i] && (i - j < 3 || p[j + 1, i - 1]))
                    {
                        Console.WriteLine("s[j]-" + s[j] + "s[i]-" + s[i]);
                        if (i - j >= 3)
                            Console.WriteLine("s[j]-" + s[j] + "  s[i]-" + s[i] + "i-j>=3 "+ p[j + 1, i - 1]);
                        // Its a palindrome as Ci == Cj and String[j+1...i-1] is a palindrome
                        p[j, i] = true;
                        // j == 0 because String from j to i is a palindrome and it starts from first character so means no cuts needed
                        // Else I need a cut at jth location and it will be cuts encountered till j-1 + 1
                        if (j != 0)
                            Console.WriteLine("j-1 is: " + cut[j - 1]);
                        //j == 0, This means j to i is palindrome.
                        //abba
                        min = j == 0 ? 0 : Math.Min(min, cut[j - 1] + 1);
                        Console.WriteLine("Min after update is: " + min);
                    }
                }
                cut[i] = min;
                Console.WriteLine($"Cut at {i}: " + min);
            }

            return cut[n - 1];
        }

    }
}
