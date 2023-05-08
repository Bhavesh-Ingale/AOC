using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC;

public static class Part2
{
    public static void Calculate(List<int> myList)
    {
        //Console.WriteLine(myList);
        myList.Sort();
        myList.Reverse();
        var new_list = myList.Take(3).ToList();
        //new_list.ForEach(item => { Console.WriteLine(item); });
        Console.WriteLine( (new_list.Sum())); ;
    }
}

