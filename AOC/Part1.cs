using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AOC;

public class Part1
{
    public List<int> MaxCal()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input.txt");

        var result = new List<int>();
        int counter = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                result.Add(counter);
                counter = 0;
            }
            else
            {
                counter += int.Parse(line);
            }
        }
        Console.WriteLine(result.Max());
        return result;
    }
}