using System;
using System.Linq;

namespace WordChains
{
  class Program
  {
    static void Main(string[] args)
    {
      string text = System.IO.File.ReadAllText(@"C:\Users\andrew.frey\Documents\PROJECTS\katas\WordChains\wordlist.txt");
      string[] words = text.Split("\n");
      Console.WriteLine("Words: {0:N}", words.Length);

      string start = args[0];
      string end = args[1];

      if (start.Length != end.Length)
      {
        Console.WriteLine("Words must be the same length");
        return;
      }

      string[] sameLengths = words.Where(s => s.Length == start.Length).ToArray<string>();
      Console.WriteLine("Words with same length: {0:N}", sameLengths.Length);





      // find words that are one away

      // find words one away from those words (no repeats or backsteps)

      // repeat until we find a path that leads to the end
    }


    static string[] OneLetterAway(string start, string[] list)
    {
      string[] oneAway = list.Where(s =>
        {
          int count = 0;
          for (int i = 0; i < start.Length; i++)
          {
            if (start[i] == s[i])
            {
              count++;
            }
          }
          return (count == 1);
        }).ToArray<string>();

      return oneAway;
    }
  }
}
