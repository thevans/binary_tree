using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }
        public Node Parent { get; set; }

        public Node(List<Group> groups, Node parent = null, string nodeName = null)
        {
            Nodes = new List<Node>();
            Parent = parent;
            if (groups.Count > 0)
            {
                if (nodeName != null)
                {
                    Name = nodeName;
                }
                else
                {
                    Name = GetMasterNodeName(groups);
                }

                if (string.IsNullOrEmpty(Name))
                {
                    return;
                }

                foreach (var group in groups)
                {
                    var newGroupsList = new List<Group>(groups);
                    newGroupsList.Remove(group);
                    if (group.Name == Name)
                    {
                        AddNode(newGroupsList, group);
                    }
                    else if (parent != null && group.Name == parent.Name)
                    {
                        parent.AddNode(newGroupsList, group);
                    }
                    else
                    {
                        foreach (var node in Nodes)
                        {
                            node.AddNode(newGroupsList, group);
                        }
                    }

                }


            }

        }

        private void AddNode(List<Group> groups, Group group)
        {
            if (group.Name != Name)
            {
                return;
            }

            foreach (var node in Nodes)
            {
                if (node.Name == group.GroupLink)
                {
                    return;
                }
            }

            Nodes.Add(new Node(groups, this, group.GroupLink));
        }

        public string PrintTree()
        {
            var result = "";
            if (Parent != null)
            {
                result = "[" + Name;
            }
            else
            {
                result = Name + "[";
            }

            foreach (var node in Nodes.OrderBy(o => o.Name))
            {
                result += node.PrintTree();
            }

            return result + "]";
        }

        private string GetMasterNodeName(List<Group> groups)
        {
            foreach (var group1 in groups)
            {
                bool isGroupLinked = false;
                foreach (var group2 in groups)
                {
                    if (group1.Name == group2.GroupLink)
                    {
                        isGroupLinked = true;
                        break;
                    }
                }
                if (isGroupLinked)
                {
                    continue;
                }
                else
                {
                    return group1.Name;
                }
            }
            return "";
        }

        public static List<Group> GetGroups(string str)
        {
            List<Group> groups = new List<Group>();
            var strGroups = str.Trim().Split(' ');
            foreach (var strGroup in strGroups)
            {
                groups.Add(new Group(strGroup));
            }
            return groups;
        }
    }
}
