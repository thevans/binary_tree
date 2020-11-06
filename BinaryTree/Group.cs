using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Group
    {
        public string Name { get; set; }
        public string GroupLink { get; set; }

        public Group(string str)
        {
            Name = str.Split(',')[0].Replace("[", "");
            GroupLink = str.Split(',')[1].Replace("]", "");
        }
    }
}
