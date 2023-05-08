using System.Text.RegularExpressions;

public class Day5
{
    public static void day5_P1()
    {
        Console.WriteLine("Part 1");
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day5.txt");
        (Dictionary<int, LinkedList<char>> stack_line, int stack_line_position) = create_dict(lines);

        for(int ind = stack_line_position+2;ind < lines.Length; ind++)
        {
            string temp_line = lines[ind];
            temp_line = temp_line.Replace("move ", "");
            temp_line = temp_line.Replace(" from ", " ");
            temp_line = temp_line.Replace(" to ", " ");
            //Console.WriteLine(temp_line);

            string[] split_line = temp_line.Split(" ");
            int move_quantity = Convert.ToInt32(split_line[0]);
            int from_stack = Convert.ToInt32(split_line[1]);
            int to_stack = Convert.ToInt32(split_line[2]);

            for (int counter = 1; counter <= Convert.ToInt32(move_quantity); counter++)
            {
                char last_item = stack_line[from_stack].Last();
                stack_line[to_stack].AddLast(last_item);
                stack_line[from_stack].RemoveLast();
            }
        }
        foreach(int ind in stack_line.Keys)
        {
            //Console.WriteLine(ind);
            //foreach (char item in stack_line[ind])
            //{
            //    Console.Write(item);
            //}
            Console.Write(stack_line[ind].Last());
        }
        Console.WriteLine();
    }
    public static (Dictionary<int, LinkedList<char>>, int) create_dict(string[] lines)
    {
        Dictionary<int, LinkedList<char>> stack_lines = new ();

        //to get the position/index of line where all characters are numbers
        int stack_lines_position = 0;

        //populate stack_lines dict with keys and empty list
        foreach (string line in lines)
        {
            stack_lines_position++;
            if (line.All(c=>char.IsWhiteSpace(c) || char.IsDigit(c)))
            {
                //Console.WriteLine(line);
                string stack_lines_base = Regex.Replace(line.Trim(), @"\s+", " ");
                foreach (string number in stack_lines_base.Split(" "))
                {
                    stack_lines.Add(int.Parse(number), new());
                }
                break;
            }   
        }
        stack_lines_position--;

        //populate each key in dict with values
        for(int i = 0;i < stack_lines_position; i++)
        {
            foreach(int number in stack_lines.Keys)
            {
                //get character at position of number
                char char_at_position = lines[i][lines[stack_lines_position].IndexOf($"{number}")];
                if (char.IsLetter(char_at_position))
                {
                    stack_lines[number].AddFirst(char_at_position);
                }
            }
        }
        return (stack_lines, stack_lines_position);
    }
    public static void day5_P2()
    {
        Console.WriteLine("Part 2");
        string[] lines = File.ReadAllLines("C:\\Users\\b.ingale\\Desktop\\Input Day5.txt");
        (Dictionary<int, LinkedList<char>> stack_line, int stack_line_position) = create_dict(lines);

        for (int ind = stack_line_position + 2; ind < lines.Length; ind++)
        {
            string temp_line = lines[ind];
            temp_line = temp_line.Replace("move ", "");
            temp_line = temp_line.Replace(" from ", " ");
            temp_line = temp_line.Replace(" to ", " ");
         
            string[] split_line = temp_line.Split(" ");
            int move_quantity = Convert.ToInt32(split_line[0]);
            int from_stack = Convert.ToInt32(split_line[1]);
            int to_stack = Convert.ToInt32(split_line[2]);

            LinkedList<char> move_list = new();

            for (int counter = 1; counter <= Convert.ToInt32(move_quantity); counter++)
            {
                move_list.AddFirst(stack_line[from_stack].Last());
                stack_line[from_stack].RemoveLast();
            }
            foreach(char c in move_list)
            {
                stack_line[to_stack].AddLast(c);
            }
        }
        foreach (int ind in stack_line.Keys)
        {
            Console.Write(stack_line[ind].Last());
        }
    }
}
