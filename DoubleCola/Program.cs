using System;

namespace DoubleCola
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };

      int n;
      if (Int32.TryParse(args[0], out n))
      {
        Console.WriteLine("n = {0:N}", n);

        int r = 0; // round of drinks
        int s = 0; // sum / end of current round

        while (s < n)
        {
          s = s + 5 * Convert.ToInt32(Math.Pow(2, r)); // s = s + 5*2^r
          r++;
        }
        r--;

        Console.WriteLine("r = {0:N}", r);

        s = s - 5 * Convert.ToInt32(Math.Pow(2, r)); // undo the last sum that made s > r 

        Console.WriteLine("s = {0:N}", s);

        int diff = n - s;
        Console.WriteLine("diff = {0:N}", diff);

        // generate line
        int t = Convert.ToInt32(Math.Pow(2, r));
        int l = 5 * t;

        string[] line = new string[l];

        int pos = 0;
        for (int i = 0; i < 5; i++)
        {
          for (int j = 0; j < t; j++)
          {
            line[pos] = names[i] + j;
            pos++;
          }
        }
        Console.WriteLine(string.Join(", ", line));

        Console.WriteLine("Next up is {0:G}", line[diff]);
      }
      else
      {
        Console.WriteLine("Please enter a number");
      }
    }
  }
}
