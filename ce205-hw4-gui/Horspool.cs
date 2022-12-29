using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class Horspool
    {

        /// <summary>
        /// This method will take a string and return a string with the first letter of each word capitalized.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int ShiftMyTable(string pattern, string text, int startIndex)
        {
            bool baskaVar = false;

            /*
             * Create a table to store results of sub-problems
             */
            int[] shiftTable = new int[256];

            for (int i = 0; i < 256; i++)
            {
                shiftTable[i] = pattern.Length;
            }

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                shiftTable[pattern[i]] = pattern.Length - i - 1;
            }

            int index = startIndex;
            /*
             * Start from the right-most-bottom-most corner and
             */
            while (index <= text.Length - pattern.Length)
            {
                int i = pattern.Length - 1;
                while (i >= 0 && pattern[i] == text[index + i])
                {
                    i--;
                }
                if (i < 0)
                {
                    return index;
                }
                else
                {
                    index += shiftTable[text[index + pattern.Length - 1]];
                }
            }
            return -1;
        }

    }
}
