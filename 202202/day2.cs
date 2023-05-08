using System;

public class Day2
{
	public static void day2()
	{
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day2.txt");
        var total = new List<int>();
        foreach (string line in lines) 
        {
            if (line[0] == 'A')
            {
                if (line[2] == 'X')
                {
                    total.Add(3 + 0);
                }
                if (line[2] == 'Y')
                {
                    total.Add(1 + 3);
                }
                if (line[2] == 'Z')
                {
                    total.Add(2 + 6);
                }
            }

            if (line[0] == 'B' && line[2] == 'X')
            {
                total.Add(1 + 0);
            }
            else if (line[0] == 'B' && line[2] == 'Y')
            {
                total.Add(2 + 3);
            }
            else if (line[0] == 'B' && line[2] == 'Z')
            {
                total.Add(3 + 6);
            }
            else if (line[0] == 'C' && line[2] == 'X')
            {
                total.Add(2 + 0);
            }
            else if (line[0] == 'C' && line[2] == 'Y')
            {
                total.Add(3 + 3);
            }
            else if (line[0] == 'C' && line[2] == 'Z')
            {
                total.Add(1 + 6);
            }
            //Console.WriteLine(line); 
        }
        //total.ForEach(x => Console.WriteLine(x));
        Console.WriteLine(total.Sum());
    }
}
