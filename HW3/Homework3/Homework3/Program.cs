using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                n = Integer.parseInt(args[0]);
            }
            catch (NumberFormatException e)
            {
                Console.WriteLine(args[0] + " is not a valid number.");
                return;
            }

            LinkedList<String> output = generateBinaryRepresentationList(n);

            int maxLength = output.Count;
            for (String : output)
            {
                for (int i = 0; i < maxLength - s.Length(); i++)
                {
                    Console.WriteLine(" ");
                }
                Console.WriteLine(s);
            }
        }

        static LinkedList<String> gnerateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            LinkedList<String> output = new LinkedList<String>();

            if (n < 1)
            {
                return output;
            }

            q.push(new StringBuilder("1"));

            while (n-- > 0)
            {
                StringBuilder sb = q.pop();

                output.AddLast(sb.ToString());

                StringBuilder sbc = new StringBuilder(sb.ToString());

                sb.Append('0');
                q.push(sb);

                sbc.Append('1');
                q.push(sbc);
            }
        }
    }
}
