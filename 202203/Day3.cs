using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

public class Day3
{
	public static void day3()
	{
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day3.txt");

        //var sum_priorities = new List<int>();
        var sum_priorities = 0;

        var rucksack = new Dictionary<int, int>();
        var counter = 0;

        for (char letter = 'a'; letter <= 'z'; letter++) { rucksack.Add(letter, ++counter); }
        
        for (char letter = 'A'; letter <= 'Z'; letter++) { rucksack.Add(letter, ++counter); }

        //var updated_lines = new List<string>();

        int lines_count = 0;

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            //    foreach (char letter in line.Substring(0, line.Length/2).Distinct()) 
            //    { 
            //        if (line.Substring(line.Length / 2).Distinct().Contains(letter))
            //        {
            //            sum_priorities += rucksack[letter];
            //            //Console.WriteLine(letter);
            //        }
            //    }
            //}
            //Console.WriteLine(sum_priorities);

            lines_count++;
            if (lines_count%3==0)
            {
                foreach(char letter in line.Distinct())
                {
                    if ((lines[lines_count-2].Contains(letter)) && (lines[lines_count - 3].Contains(letter))) 
                    { 
                        sum_priorities += rucksack[letter]; 
                    }
                }
                //updated_lines.Add(lines[lines_count-1]+ lines[lines_count-2]+ lines[lines_count-3]);
            }

        }
        //updated_lines.ForEach(line => {
        //    foreach (char letter in line.Distinct())
        //    {

        //    } 
        //});
        Console.WriteLine(sum_priorities);
    }
}
