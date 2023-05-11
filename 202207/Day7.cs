//not final, answers do not tally

using System;
using System.Xml.XPath;

public class Day7
{
	public static void day7_P1()
	{
        Console.WriteLine("Part 1");

        //string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day7.txt");
        string[] lines = File.ReadAllLines("C:\\Users\\Bhavesh\\Desktop\\Input Day7.txt");

        var pathing = new Dictionary<string, double>();

        string current_path = "/home";

        pathing.Add(current_path, 0);

        //Console.WriteLine(pathing);

        foreach (string line in lines)
        {
            if (line[0] == '$')
            {

                string command = line;
                // maybe nothing to do after checking for ls
                if (line.Substring(2, 2) == "ls") ;
                if (line.Substring(2,2)=="cd")
                {
                    // taking user home
                    if (line[5..] == "/")
                    {
                        current_path = "/home";
                    }
                    // taking user a step up
                    else if (line[5..] == "..")
                    {
                        current_path = current_path.Substring(0, current_path.LastIndexOf("/"));

                    }
                    // taking user to a specific folder
                    // cd to a specific folder
                    else
                    {
                        current_path += $"/{line[5..]}";
                        pathing.Add(current_path, 0);
                    }
                }
            }
            else
            {

                // check if first half of the line has all digits
                // if yes then store the later part as the name of the file
                if (line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0].All(c => char.IsDigit(c)))
                {
                    Console.WriteLine("file: "+line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]+ $" in {current_path}");
                    pathing[current_path] += double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                    Console.WriteLine($"path {current_path} has {pathing[current_path]} bytes");
                    Console.WriteLine($"Added {double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])} to {current_path}");
                    foreach (var key in pathing.Keys)
                    {
                        if (key.Contains(current_path[..current_path.LastIndexOf("/")]) && key!=current_path)
                        {
                            pathing[key] += double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                            Console.WriteLine($"Added {double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])} to {key}");
                        }
                        //Console.WriteLine($"{key}: {pathing[key]}");
                    }
                }
                // else the first half will be a directory
                // followed by the name of the folder
                else
                {
                    Console.WriteLine("dir: "+line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]+$" in {current_path}");
                    //Console.WriteLine(pathing[current_path]);
                }

            }
        }
        Console.WriteLine("Printing all");
        // to display all the files and folders if needed to check
        foreach (var key in pathing.Keys)
        {
            Console.WriteLine($"{key}: {pathing[key]}");
        }

    }
    public static void day7_P2()
    {
        Console.WriteLine("Part 2");
    }
}
