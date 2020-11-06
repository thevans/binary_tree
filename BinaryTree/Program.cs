using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "[A,B] [A,C] [B,G] [C,H] [E,F] [B,D] [C,E]";
            Node node = new Node(Node.GetGroups(str));
            Console.WriteLine(node.PrintTree());
        }
    }
}
