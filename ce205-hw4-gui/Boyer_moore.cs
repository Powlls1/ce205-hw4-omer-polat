using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class Boyer_moore
    {

        /// <summary>
        /// Search word in text using Boyer-Moore algorithm
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public int BoyerMoore(string text, string pattern)
        {
            /*
             * Preprocess the pattern to generate the bad character and good suffix tables
             */
            int[] badChar = new int[256];
            int[] goodSuffix = new int[pattern.Length];
            Preprocess(pattern, badChar, goodSuffix);

            /*
             * Initialize the shift variables
             */
            int m = pattern.Length;
            int n = text.Length;
            int i = 0;

            /*
             * Search for the pattern in the text
             */
            while (i <= n - m)
            {
                int j = m - 1;

                /*
                 * Check the characters in the pattern and text from right to left
                 */
                while (j >= 0 && pattern[j] == text[i + j])
                {
                    j--;
                }

                /*
                 * If the pattern was found, return the index of the first character
                 */
                if (j < 0)
                {
                    return i;
                }

                /*
                 * Otherwise, shift the text by the maximum of the bad character and good suffix shifts
                 */
                i += Math.Max(j - badChar[text[i + j]], goodSuffix[j]);
            }

            /*
             * Return -1 if the pattern was not found
             */
            return -1;
        }

        /// <summary>
        /// Preprocess the pattern to generate the bad character and good suffix tables
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="badChar"></param>
        /// <param name="goodSuffix"></param>
        private static void Preprocess(string pattern, int[] badChar, int[] goodSuffix)
        {
            /*
             * Initialize the bad character table
             */
            for (int i = 0; i < badChar.Length; i++)
            {
                badChar[i] = -1;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                badChar[pattern[i]] = i;
            }

            /*
             * Initialize the good suffix table
             */
            int m = pattern.Length;
            int[] suffix = new int[m];
            for (int i = m - 1; i >= 0; i--)
            {
                if (i == m - 1)
                {
                    suffix[i] = m;
                }
                else
                {
                    int j = i + 1;
                    while (j < m && pattern[j] != pattern[i])
                    {
                        j = suffix[j];
                    }
                    suffix[i] = j;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (suffix[i] == m)
                {
                    goodSuffix[i] = m - i - 1;
                }
                else
                {
                    goodSuffix[i] = m - suffix[i] - 1;
                }
            }
        }

    }
}
