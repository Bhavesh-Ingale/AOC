using System;
using System.Xml.XPath;

internal class Day7
{
    // Returns Dict with path and the utilized bytes
    public static Dictionary<string, double> storage_per_path(string[] lines)
    {
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
                if (line.Substring(2, 2) == "ls")
                {
                    continue;
                }
                if (line.Substring(2, 2) == "cd")
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
                    //Console.WriteLine("file: "+line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]+ $" in {current_path}");
                    pathing[current_path] += double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                    //Console.WriteLine($"path {current_path} has {pathing[current_path]} bytes");
                    //Console.WriteLine($"Added {double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])} to {current_path}");
                    foreach (var path in pathing.Keys)
                    {
                        if (current_path[..current_path.LastIndexOf("/")].Contains(path) && path != current_path)
                        {
                            pathing[path] += double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                            //Console.WriteLine($"Added {double.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])} to {path}");
                        }
                    }
                }
                // else the first half will be a directory
                // followed by the name of the folder
                else
                {
                    //Console.WriteLine("dir: " + line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1] + $" in {current_path}");
                    //Console.WriteLine(pathing[current_path]);
                }

            }
        }
        return pathing;
    }

	public static void day7_P1()
	{
        Console.WriteLine("\n"+new String('-', 5)+"Part 1"+ new String('-', 5));

        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day7.txt");
        //string[] lines = File.ReadAllLines("C:\\Users\\Bhavesh\\Desktop\\Input Day7.txt");

        var pathing = storage_per_path(lines);
        Console.WriteLine("Printing all dir whose size is less than 100000");
        // to display all the files and folders if needed to check
        double sum = 0;
        foreach (var key in pathing.Keys)
        {
            if (pathing[key]<100000)
            {
                Console.WriteLine($"{key}: {pathing[key]}");
                sum += pathing[key];
            }
            
        }
        Console.WriteLine($"sum of the total sizes of those directories: {sum} bytes");

    }
    public static void day7_P2()
    {
        Console.WriteLine("\n" + new String('-', 5) + "Part 2" + new String('-', 5));

        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day7.txt");

        var pathing = storage_per_path(lines);

        const double total_disk_space = 70000000;
        const double min_space_required = 30000000;

        var used_space = pathing["/home"];
        var space_available = total_disk_space - used_space;

        var space_to_clear = used_space - min_space_required;

        var sortedDict = from entry in pathing
                         where total_disk_space - used_space + entry.Value >= min_space_required
                         orderby entry.Value ascending 
                         select entry;
        Console.WriteLine("First Dir with amount of space min to delete, to free up space");
        foreach (var key in sortedDict)
        {
            Console.WriteLine($"{key}");
            break;
        }
    }
}
