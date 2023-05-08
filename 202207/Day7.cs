using System;

public class Day7
{
	public static void day7_P1()
	{
        Console.WriteLine("Part 1");

        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day7.txt");

        Dictionary<string, object> pathing = new();
        string current_path = "/home";

        pathing.Add("/home", new Dictionary<string, object> ());

        foreach(string line in lines)
        {
            if (line[0] == '$')
            {

                string command = line;
                if (line.Substring(2,2)=="ls")
                {

                }
                else if (line.Substring(2,2)=="cd")
                {
                    // taking user home
                    if (line.Contains("/"))
                    {
                        current_path = "/home";
                    }
                    // taking user a step up
                    else if (line.Substring(5,2)=="..")
                    {
                        current_path = current_path.Substring(0, current_path.LastIndexOf("/"));

                    }
                    // taking user to a specific folder
                    else
                    {
                        current_path = current_path + $"/{line.Substring(5)}";
                    }
                }
            }
            else
            {

                // check if line has digits in the first half, if yes then store the later part as the name of the file
                if (line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0].All(c => char.IsDigit(c)))
                {

                }
                // else the first half of the line will be a directory followed by the name of the folder

            }
        }

    }
    public static void day7_P2()
    {
        Console.WriteLine("Part 2");
    }
}
