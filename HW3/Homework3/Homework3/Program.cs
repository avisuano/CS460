using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class Program
    {
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
                Console.WriteLine(args[0] + " is not a valid number.");
                return;
            }

            LinkedList<String> output = Program.GenerateBinaryRepresentationList(n);

            int maxLength = output.Count;

            foreach (var s in output)
            {
                for (int i = 0; i < maxLength - s.Count(); i++)
                {
                    Console.WriteLine(" ");
                }
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static LinkedList<String> GenerateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            LinkedList<String> output = new LinkedList<String>();

            if (n < 1)
            {
                return output;
            }

            q.Push(new StringBuilder("1"));

            while (n-- > 0)
            {
                StringBuilder sb = q.Pop();

                output.AddLast(sb.ToString());

                StringBuilder sbc = new StringBuilder(sb.ToString());

                sb.Append('0');
                q.Push(sb);

                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }
    }
}
