using System;
using System.Diagnostics.Metrics;

public class Day6
{
	public static void day6_P1()
	{
        Console.WriteLine("Part 1");
        
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day6.txt");
        string line = lines[0];
        List<char> distinct_chars = new();
        int counter = 0;

        while (counter<=line.Count())
        {
            distinct_chars = line.Substring(counter, 4).Distinct().ToList();
            counter += 1;

            if (distinct_chars.Count == 4)
            {
                Console.WriteLine($"{line[counter + 3]} at { counter+3 }");
                break;
            }
        }

    }
    public static void day6_P2()
    {
        Console.WriteLine("Part 2");

        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day6.txt");
        string line = lines[0];
        List<char> distinct_chars = new();
        int counter = 0;

        while (counter <= line.Count())
        {
            distinct_chars = line.Substring(counter, 14).Distinct().ToList();
            counter += 1;

            if (distinct_chars.Count == 14)
            {
                Console.WriteLine($"{line[counter + 13]} at {counter + 13}");
                break;
            }
        }
    }
}
