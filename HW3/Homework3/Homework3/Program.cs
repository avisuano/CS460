using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class Program
    {
        /// <summary>
        /// This is the main driver of the program, tests the function below
        /// </summary>
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            int n = 10;

            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke the program with a valid number.");
                return;
            }

            try
            {
                n = int.Parse(args[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("'"+args[0]+"'" + " is not a valid number.");
                return;
            }

            LinkedList<String> output = Program.GenerateBinaryRepresentationList(n);

            // This is supposed to pring it right justified. This is the most likely area I screwed up
            // It doesn't quite look right.
            int maxLength = output.Count;
            foreach (var s in output)
            {
                for (int i = 0; i < maxLength - s.Count(); i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// This prints the binary representation of all the numberes from 1 to n.
        /// Uses the FIFO queue to traverse the binary tree.
        /// </summary>
        /// <param name="n">The value to be turned into binary</param>
        /// <returns>The binary of each value</returns>
        static LinkedList<String> GenerateBinaryRepresentationList(int n)
        {
            // Creates an empty queue to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // List to store the binary values
            LinkedList<String> output = new LinkedList<String>();

            if (n < 1)
            {
                // Non-negative numbers only (no zeroes either)
                return output;
            }
            
            // Grap the first binary number and push it into the queue
            q.Push(new StringBuilder("1"));

            // This builds the BFS
            while (n-- > 0)
            {
                // Prints the front of the queue
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                // Copy the front of the queue
                StringBuilder sbc = new StringBuilder(sb.ToString());

                // This is the left child
                sb.Append('0');
                q.Push(sb);

                // This is the right child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }
    }
}
