using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class HuntSzymanski
    {

        /// <summary>
        /// This method will take a string and return a string with the first letter of each word capitalized.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string FindLargestCommonSubsequence(string a, string b)
        {
            int i, j;
            int m = a.Length;
            int n = b.Length;

            /*
             * Create a table to store results of sub-problems
             */
            int[,] dp = new int[m + 1, n + 1];

            /*
             * Fill dp[,] in bottom up manner
             */
            for (i = 0; i <= m; i++)
            {
                for (j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (a[i - 1] == b[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            /*
             * String to store the longest common subsequence
             */
            string lcs = "";

            /*
             * Start from the right-most-bottom-most corner and
             * one by one store characters in lcs[]
             */
            i = m;
            j = n;
            while (i > 0 && j > 0)
            {
                /*
                 * If current character in X[] and Y are same, then
                 * current character is part of LCS
                 */
                if (a[i - 1] == b[j - 1])
                {
                    /*
                     * Prepend current character to the result
                     */
                    lcs = a[i - 1] + lcs;
                    i--;
                    j--;
                }

                /*
                 * If not same, then find the larger of two and
                 * go in the direction of larger value
                 */
                else if (dp[i - 1, j] > dp[i, j - 1])
                    i--;
                else
                    j--;
            }

            return lcs;
        }

    }
}
