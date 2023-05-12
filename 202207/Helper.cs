using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202207
{
    public class Helper
    {
        public class Node
        {
            public string Name { get; set; }
            public Node Parent { get; set; }
            public List<Node> Childs { get; set; }
            public int Size { get; set; }
        }
        public static object SolvePartOne(List<Node> result)
        {
            return result.Where(x => x.Size <= 100000).Select(x => x.Size).Sum();
        }
        public static object SolvePartTwo(List<Node> result)
        {
            Node root = result.Where(x => x.Name == "/").FirstOrDefault();
            root.Size += root.Childs.Sum(s => s.Size);
            int needSpace = 30000000 - (70000000 - root.Size); return result.Select(x => x.Size).Where(x => x >= needSpace).Min();
        }
        public static List<Node> GetNodeTree(string[] input)
        {
            List<Node> result = new List<Node>();
            Node currentNode = null;
            foreach (string line in input)
            {
                if (line.StartsWith("$"))
                {
                    if (line.Equals("$ ls"))
                        continue;
                    if (!line.Equals("$ cd .."))
                    {
                        string nodeName = line.Split(' ')[2];
                        if (currentNode == null)
                        {
                            Node node = new Node();
                            node.Name = nodeName; node.Parent = currentNode; currentNode = node; result.Add(node);
                        }
                        else
                        {
                            Node child = currentNode.Childs.Where(x => x.Name == nodeName).FirstOrDefault();
                            child.Parent = currentNode;
                            currentNode = child;
                        }
                    }
                    else
                    {
                        int size = currentNode.Size; currentNode = currentNode.Parent; if (currentNode.Name != "/")
                            currentNode.Size += size;
                    }
                    continue;
                }
                else if (line.StartsWith("dir"))
                {
                    if (currentNode.Childs == null)
                        currentNode.Childs = new List<Node>(); Node child = new Node();
                    child.Name = line.Split(' ')[1]; currentNode.Childs.Add(child); result.Add(child);
                }
                else
                {
                    int values = int.Parse(line.Split(' ')[0]);
                    currentNode.Size += values;
                }
            }
            return result;

        }
    }
}
