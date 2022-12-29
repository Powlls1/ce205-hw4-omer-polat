using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce205_hw4_gui;
using static ce205_hw4_gui.TrieAlgorithm;
using System.Collections.Generic;

namespace ce205_hw4_test
{
    [TestClass]
    public class UnitTest1
    {
        //############################### HORSPOOL ALGORITHM TEST #################################################
        [TestMethod]
        public void HorspoolGoodTest()
        {
            Horspool h = new Horspool();
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            string pattern = "dolor";
            int index = h.ShiftMyTable(pattern, text, 0);
            Assert.AreEqual(12, index);
        }
        
                
        //######################################   NEEDLEMAN WUNSCH ##########################################
        [TestMethod]
        public void TestNeedleman()
        {
            Needleman_Wunsch needleman = new Needleman_Wunsch();
            string s1 = "AGCAT";
            string s2 = "GAC";

            string expected = "AGCAT\n-G-AC";
            string actual = needleman.Align(s1, s2);

            Assert.AreEqual(expected, actual);
        }
        //########################## SMITHWATERMAN ######################################
        [TestMethod]
        public void TestSmithWaterman()
        {
            SmithWaterman smith = new SmithWaterman();
            // Arrange
            string seq1 = "AGCT";
            string seq2 = "ACCT";

            // Act
            string actual = smith.SmithWatermanAlign(seq1, seq2);
            string expected = "AGCT\nACCT";
            // Assert
            Assert.AreEqual(expected, actual);
        }
        //################################### BOYER MOORE ALGORTIHM ####################
        [TestMethod]
        public void TestBoyerGoodase()
        {
            Boyer_moore boyer = new Boyer_moore();
            string stringToSearch = "The quick brown fox jumps over the lazy dog.";
            string pattern = "fox";
            int expectedResult = 16;
            int actualResult = boyer.BoyerMoore(stringToSearch, pattern);
            Assert.AreEqual(expectedResult, actualResult);
        }

        //################################# TRIE ALGORITHM ############################
        [TestMethod]
        public void TestTrie()
        {
            Trie trie = new Trie();
            TrieAlgorithm.Trie.Insert("hello");
            TrieAlgorithm.Trie.Insert("world");
            TrieAlgorithm.Trie.Insert("helix");
            TrieAlgorithm.Trie.Insert("helium");

            List<string> words = trie.SearchPrefix("hel");
            CollectionAssert.AreEqual(new[] { "hello", "helix", "helium" }, words);

            words = trie.SearchPrefix("wor");
            CollectionAssert.AreEqual(new[] { "world" }, words);

        }
        //############################### HUNT MCLLORY ##########################
        [TestMethod]
        public void TestFindLargestCommonSubsequence()
        {
            // Test with simple input
            string lcs = HuntSzymanski.FindLargestCommonSubsequence("ABCBDAB", "BDCABA");
            Assert.AreEqual("BDAB", lcs);

            // Test with empty input
            lcs = HuntSzymanski.FindLargestCommonSubsequence("", "BDCABA");
            Assert.AreEqual("", lcs);

            // Test with identical input
            lcs = HuntSzymanski.FindLargestCommonSubsequence("ABCBDAB", "ABCBDAB");
            Assert.AreEqual("ABCBDAB", lcs);

            // Test with no common characters
            lcs = HuntSzymanski.FindLargestCommonSubsequence("XYZ", "ABC");
            Assert.AreEqual("", lcs);
        }

        //############################### KNUTH-MORRIS-PRATT ALGORITHM TEST #################################################
        [TestMethod]
        public void KMPGoodTest()
        {
            Knuth_Morris_Pratt k = new Knuth_Morris_Pratt();
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas congue.";
            string pattern = "congue";
            int index = k.KMPSearch(text, pattern, 0);
            Assert.AreEqual(-1, index);
        }
    }
}
