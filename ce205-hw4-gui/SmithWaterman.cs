using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class SmithWaterman
    {

        public string SmithWatermanAlign(string s1, string s2)
        {
            int i, j;
            // Initialize the matrices
            int[,] H = new int[s1.Length + 1, s2.Length + 1];
            int[,] E = new int[s1.Length + 1, s2.Length + 1];
            int[,] F = new int[s1.Length + 1, s2.Length + 1];

            // Initialize the gap penalty
            int gap = -1;

            // Initialize the scoring matrix
            Dictionary<char, Dictionary<char, int>> scoreMatrix = new Dictionary<char, Dictionary<char, int>>
    {
        { 'A', new Dictionary<char, int> { { 'A', 2 }, { 'C', -1 }, { 'G', 0 }, { 'T', -1 } } },
        { 'C', new Dictionary<char, int> { { 'A', -1 }, { 'C', 2 }, { 'G', -1 }, { 'T', 0 } } },
        { 'G', new Dictionary<char, int> { { 'A', 0 }, { 'C', -1 }, { 'G', 2 }, { 'T', -1 } } },
        { 'T', new Dictionary<char, int> { { 'A', -1 }, { 'C', 0 }, { 'G', -1 }, { 'T', 2 } } }
    };

            // Fill in the matrices
            for (i = 1; i <= s1.Length; i++)
            {
                for (j = 1; j <= s2.Length; j++)
                {
                    E[i, j] = Math.Max(H[i, j - 1] + gap, E[i, j - 1] + gap);
                    F[i, j] = Math.Max(H[i - 1, j] + gap, F[i - 1, j] + gap);
                    H[i, j] = Math.Max(H[i - 1, j - 1] + scoreMatrix[s1[i - 1]][s2[j - 1]], Math.Max(E[i, j], F[i, j]));
                }
            }

            // Traceback to find the optimal alignment
            string align1 = "";
            string align2 = "";
            i = s1.Length;
            j = s2.Length;
            while (i > 0 || j > 0)
            {
                if (i > 0 && H[i, j] == H[i - 1, j] + gap)
                {
                    align1 += s1[i - 1];
                    align2 += "-";
                    i--;
                }
                else if (j > 0 && H[i, j] == H[i, j - 1] + gap)
                {
                    align1 += "-";
                    align2 += s2[j - 1];
                    j--;
                }
                else
                {
                    align1 += s1[i - 1];
                    align2 += s2[j - 1];
                    i--;
                    j--;
                }
            }

            // Reverse the alignments
            align1 = Reverse(align1);
            align2 = Reverse(align2);

            // Return the alignment as a single string
            return align1 + "\n" + align2;
        }
        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
