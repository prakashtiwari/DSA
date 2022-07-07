using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.Heap
{
    public class PriorityQueue<T>
    {
        public class Node
        {
            public double Priority { get; set; }
            public T Object { get; set; }
        }
        List<Node> queue = new List<Node>();
        int heapSize = -1;
        bool _isMinPriorityQueue;
        public int Count { get { return queue.Count; } }

        public PriorityQueue(bool isMinPriority)
        {
            _isMinPriorityQueue = isMinPriority;
        }
        private void Swap(int i, int j)
        {

            var temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }
        private int ChildL(int i)
        {
            return 2 * i + 1;
        }
        private int ChildR(int i)
        {

            return 2 * i + 2;
        }
        private void MaxHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);
            int heighest = i;
            if (left <= heapSize && queue[heighest].Priority < queue[left].Priority)
            {
                heighest = left;
            }
            if (right <= heapSize && queue[heighest].Priority < queue[right].Priority)
            {
                heighest = right;
            }
            if (heighest != i)
            {
                Swap(heighest, i);
                MaxHeapify(heighest);

            }

        }
        public void MinHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);
            int lowest = i;
            if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
            {
                lowest = left;

            }
            if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
            {
                lowest = right;
            }
            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }
        private void BuildHeaMax(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
        private void BuildMinHeap(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
            {
                Swap((i - 1) / 2, i);
                i = (i - 1) / 2;
            }

        }
        public void Enqueue(double priority, T obj)
        {
            Node node = new Node() { Priority = priority, Object = obj };
            queue.Add(node);
            heapSize++;
            if (_isMinPriorityQueue)
            {
                BuildMinHeap(heapSize);
            }
            else
            {
                BuildHeaMax(heapSize);
            }

        }
        public T Dequeue()
        {
            if (heapSize > -1)
            {
                var returnVal = queue[0].Object;
                queue[0] = queue[heapSize];
                queue.RemoveAt(heapSize);
                heapSize--;
                if (_isMinPriorityQueue)
                {

                    MinHeapify(0);
                }
                else
                {
                    MaxHeapify(0);
                }
                return returnVal;
            }
            else
            {
                throw new Exception("Queue is empty.");
            }

        }
        public void UpdatePriority(T obj, double priority)
        {
            int i = 0;
            for (; i <= heapSize; i++)
            {
                Node node = queue[i];
                if (Object.ReferenceEquals(node.Object, obj))
                {
                    node.Priority = priority;
                    if (_isMinPriorityQueue)
                    {

                        BuildMinHeap(i);
                        MinHeapify(i);
                    }
                    else
                    {
                        BuildHeaMax(i);
                        MaxHeapify(i);

                    }
                }
            }
        }
        public bool IsInQueue(T obj)
        {
            foreach (Node node in queue)
            {
                if (Object.ReferenceEquals(node.Object, obj))
                {
                    return true;
                }
                else
                    return false;

            }
            return false;
        }
        public T Top()
        {
            if (heapSize > -1)
            {
                var returnVal = queue[0].Object;
                return returnVal;
            }
            else
            {
                throw new Exception("Queue is empty!");
            
            }
        }
    }
}
