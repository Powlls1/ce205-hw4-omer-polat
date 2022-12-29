using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ce205_hw4_gui.TrieAlgorithm;

namespace ce205_hw4_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AligmentNW_Click(object sender, EventArgs e)
        {
            Needleman_Wunsch needleman = new Needleman_Wunsch();
            string input1 = NWtextBox1.Text;
            string input2 = NWtextBox2.Text;

            // Clear the RichTextBox
            NWRichTextBox.Clear();

            // Iterate over the characters in the input strings
            for (int i = 0; i < Math.Max(input1.Length, input2.Length); i++)
            {
                // Check if the characters at the current position match
                if (i < input1.Length && i < input2.Length && input1[i] == input2[i])
                {
                    if (i < input1.Length)
                    {
                        // If they match, add them to the RichTextBox with a green color
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Green;
                        NWRichTextBox.AppendText(input1[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Green;
                        NWRichTextBox.AppendText(input2[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    NWRichTextBox.AppendText("\n");
                }
                else if (i < input1.Length && i < input2.Length && input1[i] != input2[i])
                {
                    // If they do not match, add them to the RichTextBox with a red color
                    if (i < input1.Length)
                    {
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Red;
                        NWRichTextBox.AppendText(input1[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Red;
                        NWRichTextBox.AppendText(input2[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    NWRichTextBox.AppendText("\n");
                }
                else
                {
                    // If one of the strings is shorter, add the remaining characters to the RichTextBox with a blue color
                    if (i < input1.Length)
                    {
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Blue;
                        NWRichTextBox.AppendText(input1[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        NWRichTextBox.SelectionStart = NWRichTextBox.TextLength;
                        NWRichTextBox.SelectionLength = 1;
                        NWRichTextBox.SelectionColor = Color.Blue;
                        NWRichTextBox.AppendText(input2[i].ToString());
                        NWRichTextBox.SelectionColor = NWRichTextBox.ForeColor;
                    }
                    NWRichTextBox.AppendText("-" + "\n");
                }
            }
        }

        private void SWAlignment_Click(object sender, EventArgs e)
        {
            SmithWaterman smith = new SmithWaterman();
            string gene1 = SWtextBox1.Text;
            string gene2 = SWtextBox2.Text;

            SWrichTextBox.Clear();

            for (int i = 0; i < Math.Max(gene1.Length, gene2.Length); i++)
            {
                // Check if the characters at the current position match
                if (i < gene1.Length && i < gene2.Length && gene1[i] == gene2[i])
                {
                    if (i < gene1.Length)
                    {
                        // If they match, add them to the RichTextBox with a green color
                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Green;
                        SWrichTextBox.AppendText(gene1[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                    }
                    if (i < gene2.Length)
                    {
                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Green;
                        SWrichTextBox.AppendText(gene2[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                    }
                    SWrichTextBox.AppendText("\n");
                }
                else if (i < gene1.Length && i < gene2.Length && gene1[i] != gene2[i])
                {
                    if (i < gene1.Length)
                    {

                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Red;
                        SWrichTextBox.AppendText(gene1[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                    }
                    if (i < gene2.Length)
                    {
                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Red;
                        SWrichTextBox.AppendText(gene2[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                        SWrichTextBox.AppendText("\n");
                    }
                }
                else
                {
                    if (i < gene1.Length)
                    {

                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Blue;
                        SWrichTextBox.AppendText(gene1[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                    }
                    if (i < gene2.Length)
                    {
                        SWrichTextBox.SelectionStart = SWrichTextBox.TextLength;
                        SWrichTextBox.SelectionLength = 1;
                        SWrichTextBox.SelectionColor = Color.Blue;
                        SWrichTextBox.AppendText(gene2[i].ToString());
                        SWrichTextBox.SelectionColor = SWrichTextBox.ForeColor;
                    }
                    SWrichTextBox.AppendText("-" + "\n");
                }
            }
        }

        private void HAalignment_Click(object sender, EventArgs e)
        {
            // Get the input strings and the pattern
            string input1 = HAtextBox1.Text;
            string input2 = HAtextBox2.Text;

            // Clear the RichTextBox
            HArichTextBox.Clear();

            // Iterate over the characters in the input strings
            for (int i = 0; i < Math.Max(input1.Length, input2.Length); i++)
            {
                // Check if the characters at the current position match
                if (i < input1.Length && i < input2.Length && input1[i] == input2[i])
                {
                    if (i < input1.Length)
                    {
                        // If they match, add them to the RichTextBox with a green color
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Green;
                        HArichTextBox.AppendText(input1[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Green;
                        HArichTextBox.AppendText(input2[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    HArichTextBox.AppendText("\n");
                }
                else if (i < input1.Length && i < input2.Length && input1[i] != input2[i])
                {
                    // If they do not match, add them to the RichTextBox with a red color
                    if (i < input1.Length)
                    {
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Red;
                        HArichTextBox.AppendText(input1[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Red;
                        HArichTextBox.AppendText(input2[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    HArichTextBox.AppendText("\n");
                }
                else
                {
                    // If one of the strings is shorter, add the remaining characters to the RichTextBox with a blue color
                    if (i < input1.Length)
                    {
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Blue;
                        HArichTextBox.AppendText(input1[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    if (i < input2.Length)
                    {
                        HArichTextBox.SelectionStart = HArichTextBox.TextLength;
                        HArichTextBox.SelectionLength = 1;
                        HArichTextBox.SelectionColor = Color.Blue;
                        HArichTextBox.AppendText(input2[i].ToString());
                        HArichTextBox.SelectionColor = HArichTextBox.ForeColor;
                    }
                    HArichTextBox.AppendText("-" + "\n");
                }
            }
        }

        private void KWSearch_Click(object sender, EventArgs e)
        {
            Knuth_Morris_Pratt kmp = new Knuth_Morris_Pratt();

            string[] words = KMtextBox1.Text.Split(',');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < KMrichTextBox.TextLength)
                {
                    int index = kmp.KMPSearch(word, KMrichTextBox.Text, startIndex);
                    if (index != -1)
                    {
                        KMrichTextBox.SelectionStart = index;
                        KMrichTextBox.SelectionLength = word.Length;
                        KMrichTextBox.SelectionColor = Color.Yellow;
                    }
                    else
                        break;
                    startIndex += index + word.Length;
                }
            }
        }

        private void horspoolSearch_Click(object sender, EventArgs e)
        {
            Horspool h = new Horspool();

            string[] words = HorspooltextBox.Text.Split(',');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < HorspoolrichTextBox.TextLength)
                {
                    int index = h.ShiftMyTable(word, HorspoolrichTextBox.Text, startIndex);
                    if (index != -1)
                    {
                        HorspoolrichTextBox.SelectionStart = index;
                        HorspoolrichTextBox.SelectionLength = word.Length;
                        HorspoolrichTextBox.SelectionColor = Color.Yellow;
                    }
                    else
                        break;
                    startIndex += index + word.Length;
                }
            }
        }

        private void BMsearch_Click(object sender, EventArgs e)
        {
            Horspool h = new Horspool();

            string[] words = BMtextBox.Text.Split(',');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < BMrichTextBox.TextLength)
                {
                    int index = h.ShiftMyTable(word, BMrichTextBox.Text, startIndex);
                    if (index != -1)
                    {
                        BMrichTextBox.SelectionStart = index;
                        BMrichTextBox.SelectionLength = word.Length;
                        BMrichTextBox.SelectionColor = Color.Yellow;
                    }
                    else
                        break;
                    startIndex += index + word.Length;
                }
            }
        }

        private void InsertTrie_Click(object sender, EventArgs e)
        {
            string paraf = textBox1.Text;
            char[] white = new char[] { ' ', ',', '.', '\t' };
            String[] keys = paraf.Split(white);

            TrieAlgorithm.Trie root = new TrieAlgorithm.Trie();

            // Construct trie

            int i;
            for (i = 0; i < keys.Length; i++)
            {
                richTextBox1.Text = richTextBox1.Text + keys[i] + Environment.NewLine;
                TrieAlgorithm.Trie.Insert(keys[i]);
            }
        }

        private void SearchTrie_Click(object sender, EventArgs e)
        {
            Trie trie = new Trie();
            string prefix = textBox2.Text;

            // Split the text in the insertRichTextBox into words
            string[] words = richTextBox1.Text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            richTextBox2.Clear();
            foreach (string word in words)
            {
                if (word.StartsWith(prefix))
                {
                    richTextBox2.AppendText(word + Environment.NewLine);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 200);
            string[] keys = {
                "some form, injected humour, randomised words which don't look even slightly believable. " ,
                "going passage Lorem Ipsum, need sure there isn't anything embarrassing hidden " ,
                "middle text. Lorem Ipsum generators Internet tend repeat predefined chunks " ,
                "necessary, making this first true generator Internet. uses dictionary over 200 Latin words" ,
                " combined with handful model sentence structures, generate Lorem Ipsum which looks reasonable " ,
                " generated Lorem Ipsum therefore always free from repetition, injected humour, non-characteristic words" };

            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            //string[] arrkeys = keys.Split(delimiterChars);

            KMrichTextBox.Text = keys[rand_num];
        }

        private void random1_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            NWtextBox1.Text = dna;
        }

        private void random2_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            NWtextBox2.Text = dna;
        }

        private void randomSW1_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            SWtextBox1.Text = dna;
        }

        private void RandomSW2_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            SWtextBox2.Text = dna;
        }

        private void randomHS1_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            HAtextBox1.Text = dna;
        }

        private void randomHS2_Click(object sender, EventArgs e)
        {
            int length = 2000;

            // Initialize an array of the possible DNA nucleotides
            char[] nucleotides = { 'A', 'C', 'G', 'T' };

            // Generate the random DNA sequence
            string dna = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                dna += nucleotides[rand.Next(4)];
            }

            // Display the DNA sequence in the text box
            HAtextBox2.Text = dna;
        }

        private void RandomTrie_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, 200);
            string keys = "Lorem Ipsum simply dummy text printing typesetting industry. Lorem Ipsum been industry's standard dummy text ever since 1500s, when unknown printer took galley type scrambled make type specimen book. survived only five centuries, also leap into electronic typesetting, remaining essentially unchanged. popularised 1960s with release Letraset sheets containing Lorem Ipsum passages, more recently with desktop publishing software like Aldus PageMaker including versions Lorem Ipsum." +
                "long established fact that reader will distracted readable content page when looking layout. point using Lorem Ipsum that normal distribution letters, opposed using 'Content here, content here', making look like readable English. Many desktop publishing packages page editors Lorem Ipsum their default model text, search 'lorem ipsum' will uncover many sites still their infancy. Various versions have evolved over years, sometimes accident, sometimes purpose (injected humour and the like)." +
                "Contrary popular belief, Lorem Ipsum simply random text. roots piece classical Latin literature from, making over years. Richard McClintock, Latin professor Hampden-Sydney College Virginia, looked more obscure Latin words, consectetur, from Lorem Ipsum passage, going through cites word classical literature, discovered undoubtable source. Lorem Ipsum comes from sections Finibus Bonorum Malorum (The Extremes Good Evil) Cicero, written This book treatise theory ethics, very popular during Renaissance. first line Lorem Ipsum," +
                "There many variations passages Lorem Ipsum available, majority have suffered alteration " +
                "some form, injected humour, randomised words which don't look even slightly believable. " +
                "going passage Lorem Ipsum, need sure there isn't anything embarrassing hidden " +
                "middle text. Lorem Ipsum generators Internet tend repeat predefined chunks " +
                "necessary, making this first true generator Internet. uses dictionary over 200 Latin words," +
                " combined with handful model sentence structures, generate Lorem Ipsum which looks reasonable. " +
                " generated Lorem Ipsum therefore always free from repetition, injected humour, non-characteristic words.";

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] arrkeys = keys.Split(delimiterChars);

            textBox1.Text = arrkeys[rand_num];
        }
    }
}
