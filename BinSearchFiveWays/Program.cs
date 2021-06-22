using System;

namespace BinSearchFiveWays
{
  class Program
  {
    static string Usage = "`dotnet run [int] [1]`";
    static void Main(string[] args)
    {
      int search;
      if (Int32.TryParse(args[0], out search))
      {
        string text = System.IO.File.ReadAllText(@"C:\Users\andrew.frey\Documents\PROJECTS\katas\BinSearchFiveWays\list.txt");
        string[] split = text.Split(", ");
        int[] list = new int[split.Length];

        for (int i = 0; i < split.Length; i++)
        {
          list[i] = Int32.Parse(split[i]);
        }

        int found = -1;
        switch (args[1])
        {
          case "1":
            found = SearchOne(search, list);
            break;

          default:
            Console.WriteLine(Usage);
            break;
        }

        if (found == -1)
        {
          Console.WriteLine("{0:N} not found in list.", search);
        }
        else
        {
          Console.WriteLine("{0:N} found at index {0:N}", search, found);
        }
      }
      else
      {
        Console.WriteLine(Usage);
      }
    }

    // iterative. N approx list.Length/2
    static int SearchOne(int search, int[] list)
    {
      //   Console.WriteLine(String.Join(" ", list));
      //THESE ARE INDICIES
      int lo = 0;
      int hi = list.Length - 1;
      int mid;

      while (lo <= hi)
      {
        mid = (hi + lo) / 2;
        // Console.WriteLine("{0:G} {0:G} {0:G}\n", lo, mid, hi);
        Console.WriteLine("lo = {0:G}", lo);
        Console.WriteLine("mid = {0:G}", mid);
        Console.WriteLine("hi = {0:G}", hi);
        Console.WriteLine("--------");


        if (list[mid] == search)
        {
          return mid;
        }

        if (list[mid] < search)
        {
          lo = mid;
        }
        else
        {
          hi = mid;
        }
      }

      return -1;
    }
  }
}
