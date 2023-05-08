using System;

public class Day4
{
	public static void day4_P1()
	{
        Console.WriteLine("Part 1");
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day4.txt");
        
        int either_list_contains = 0;

        foreach (string line in lines) {
            string elf1 = line.Split(',')[0];
            string elf2 = line.Split(',')[1];
            
            var elf1_range = new List<int>();
            var elf2_range = new List<int>();

            //Populating ranges
            for (int i = Int32.Parse(elf1.Split('-')[0]); i <= Int32.Parse(elf1.Split('-')[1]); i++) 
            { 
                elf1_range.Add(i); 
            }
            for (int i = Int32.Parse(elf2.Split('-')[0]); i <= Int32.Parse(elf2.Split('-')[1]); i++) { elf2_range.Add(i); }

            if (elf1_range.All(i => elf2_range.Contains(i)) || elf2_range.All(j => elf1_range.Contains(j)))
            {
                either_list_contains++;
            }

        }
        Console.WriteLine(either_list_contains);
    }
    public static void day4_P2()
    {
        Console.WriteLine("Part 2");
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day4.txt");

        int either_list_contains = 0;

        foreach (string line in lines)
        {
            string elf1 = line.Split(',')[0];
            string elf2 = line.Split(',')[1];

            var elf1_range = new List<int>();
            var elf2_range = new List<int>();
            
            //Populating ranges
            for (int i = Int32.Parse(elf1.Split('-')[0]); i <= Int32.Parse(elf1.Split('-')[1]); i++) 
            { 
                elf1_range.Add(i); 
            }
            for (int i = Int32.Parse(elf2.Split('-')[0]); i <= Int32.Parse(elf2.Split('-')[1]); i++) 
            { 
                elf2_range.Add(i); 
            }

            if (elf1_range.Any(i => elf2_range.Contains(i)) || elf2_range.Any(j => elf1_range.Contains(j)))
            {
                either_list_contains++;
            }

        }
        Console.WriteLine(either_list_contains);
    }
}
