using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class Node
    {
        public int label;
        public List<Node> neighbours;
        public Node(int lab)
        {
            label = lab;
            neighbours = new List<Node>();
        }
    }
    public class CloneGraph
    {

        public Node cloneGraph(Node node)
        {
            if (node == null)
                return null;

            Queue<Node> queue = new Queue<Node>();
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node newHead = new Node(node.label);
            queue.Enqueue(node);
            map.Add(node, newHead);
            while (queue.Count() > 0)
            {
                Node current =(Node) queue.Dequeue();///Getting the node.
                List<Node> neighbours = current.neighbours;//These neighbours should be cloned.

                foreach (var neighbour in neighbours)
                {

                    if (!map.ContainsKey(neighbour))
                    {
                        Node copy = new Node(neighbour.label);
                        map.Add(neighbour, copy);
                        map[current].neighbours.Add(copy);
                        queue.Enqueue(neighbour);
                    }
                    else
                    {
                        map[current].neighbours.Add(neighbour);
                    }

                }                
            
            }
            return newHead;


        }
    }
}
