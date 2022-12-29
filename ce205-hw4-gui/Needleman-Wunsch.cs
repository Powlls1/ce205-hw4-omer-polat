using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw4_gui
{
    public class Needleman_Wunsch
    {

        private static int MatchScore(char a, char b)
        {
            return a == b ? 2 : -1;
        }

        public string Align(string s1, string s2)
        {
            int i, j;
            int m = s1.Length;
            int n = s2.Length;

            int[,] d = new int[m + 1, n + 1];

            for (i = 0; i <= m; i++)
                d[i, 0] = -i;

            for (j = 0; j <= n; j++)
                d[0, j] = -j;

            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    int scoreDiag = d[i - 1, j - 1] + MatchScore(s1[i - 1], s2[j - 1]);
                    int scoreLeft = d[i, j - 1] - 1;
                    int scoreUp = d[i - 1, j] - 1;

                    d[i, j] = Math.Max(Math.Max(scoreDiag, scoreLeft), scoreUp);
                }
            }

            string alignment1 = "";
            string alignment2 = "";

            int i1 = m;
            int i2 = n;
            while (i1 > 0 && i2 > 0)
            {
                int score = d[i1, i2];
                int scoreDiag = d[i1 - 1, i2 - 1];
                int scoreLeft = d[i1, i2 - 1];
                int scoreUp = d[i1 - 1, i2];

                if (score == scoreDiag + MatchScore(s1[i1 - 1], s2[i2 - 1]))
                {
                    alignment1 = s1[i1 - 1] + alignment1;
                    alignment2 = s2[i2 - 1] + alignment2;
                    i1--;
                    i2--;
                }
                else if (score == scoreLeft - 1)
                {
                    alignment1 = "-" + alignment1;
                    alignment2 = s2[i2 - 1] + alignment2;
                    i2--;
                }
                else if (score == scoreUp - 1)
                {
                    alignment1 = s1[i1 - 1] + alignment1;
                    alignment2 = "-" + alignment2;
                    i1--;
                }
            }

            while (i1 > 0)
            {
                alignment1 = s1[i1 - 1] + alignment1;
                alignment2 = "-" + alignment2;
                i1--;
            }

            while (i2 > 0)
            {
                alignment1 = "-" + alignment1;
                alignment2 = s2[i2 - 1] + alignment2;
                i2--;
            }

            return alignment1 + "\n" + alignment2;
        }

    }
}
