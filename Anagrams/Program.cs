using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
  class Program
  {
    static void Main(string[] args)
    {
      string anagram = args[0];
      Console.WriteLine("Two word anagrams of '" + anagram + "':");

      Dictionary<char, int> reference = CountChars(anagram);

      string text = System.IO.File.ReadAllText(@"C:\Users\andrew.frey\Documents\PROJECTS\katas\Anagrams\words.txt");
      string[] words = (text.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s))).ToArray<string>();

      int count = 0;
      int millions = 0;
      // int billions = 0;
      bool lastPrintWasStar = false;
      foreach (string firstWord in words)
      {
        foreach (string secondWord in words)
        {
          count++;
          if (count / 100000000 > millions)
          {
            Console.Write("*");
            lastPrintWasStar = true;
            millions++;
          }
          // if (count / 1000000000 > billions)
          // {
          //   Console.WriteLine("\nChecking: " + firstWord + " " + secondWord);
          //   billions++;
          // }

          if (reference.Count == (firstWord + secondWord).Length)
          {
            Dictionary<char, int> wordPairCount = CountChars(firstWord + secondWord);

            if (reference.OrderBy(kvp => kvp.Key).SequenceEqual(wordPairCount.OrderBy(kvp => kvp.Key)))
            {
              if (lastPrintWasStar)
              {
                Console.WriteLine();
              }
              Console.WriteLine(firstWord + " " + secondWord);
            }
          }

        }
      }
    }

    static Dictionary<char, int> CountChars(string s)
    {
      Dictionary<char, int> dict = new Dictionary<char, int>();

      foreach (char c in s)
      {
        if (dict.TryGetValue(c, out int count))
        {
          dict.Remove(c);
          dict.Add(c, ++count);
        }
        else
        {
          dict.Add(c, 1);
        }
      }

      return dict;
    }
  }
}
