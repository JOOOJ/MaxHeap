using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 35, 7, 11, 15, 21, 3,9,23,71,2,0,6 };
            MaxHeap<int> heap = new MaxHeap<int>(array);
            foreach (int item in heap)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=========================");
            heap.Sort();
            foreach (int item in heap)
            {
                Console.WriteLine(item);
            }
        }
    }
}
