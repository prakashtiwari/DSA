using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            if (words == null || words.Length == 0)
            {
                return string.Empty;
            }
            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();
            HashSet<char> set = new HashSet<char>(); // This set will contain unique characters from All the words.
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    set.Add(word[i]);
                }

            }
            int[] indegree = new int[26];
            for (int k = 1; k < words.Length; k++)
            {
                string prevString = words[k - 1];
                string currString = words[k];
                for (int i = 0; i < Math.Min(prevString.Length, currString.Length); i++)
                {
                    char prevChar = prevString[i];
                    char currChar = currString[i];
                    if (prevChar != currChar)
                    {
                        if (!graph.ContainsKey(prevChar))
                        {
                            graph.Add(prevChar, new HashSet<char>());
                        }
                        if (!graph[prevChar].Contains(currChar))
                        {

                            indegree[currChar - 'a']++;
                        }
                        graph[prevChar].Add(currChar);
                        break;

                    }

                }

            }

            Queue<char> queue = new Queue<char>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    char c = (char)('a' + i);
                    if (set.Contains(c))
                    {
                        queue.Enqueue(c);
                    }


                }

            }
            StringBuilder sb = new StringBuilder();
            //This is BFS approach
            while (queue.Count > 0)
            {
                char c = queue.Dequeue();//Remove the character having 0 degree from the queue
                sb.Append(c);
                if (graph.ContainsKey(c))
                {
                    foreach (var l in graph[c])
                    {
                        indegree[l - 'a']--;// Decrease the indegree of the node
                        if (indegree[l - 'a'] == 0)
                        {
                            queue.Enqueue(l);  // If in-degree of node is 0 then traverse.

                        }
                    }
                }

            }
            return sb.Length == 0 ? "" : sb.ToString();            
        }
    }
}
