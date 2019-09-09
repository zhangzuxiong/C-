using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "000123";
            string s2 = "12345";
            Console.WriteLine(s1.CompareTo(s2));

            Queue<int> queue = new Queue<int>(5);
            Console.WriteLine(queue.Pop());
            queue.Push(1);
            queue.Push(5);
            queue.Push(3);
            queue.Push(4);
            queue.Push(2);
            Console.WriteLine(queue.Pop());
            queue.Push(6);
            //Console.WriteLine(queue.Pop()+"\t"+queue.Pop());
            queue.Show();

            long a = 123456789012345;
            long b = 1234567890123;
            long res = a + b;
            Console.WriteLine(res+"\n");

            
            Console.WriteLine(MyMath.Add(a.ToString(),b.ToString()));
            string l = "123456789012345678901234567890";
            string r = "987654321098765432109876543210";
            Console.WriteLine(l + "\n" + r + "\n" + MyMath.Add(l, r));

            Console.WriteLine("500+500={0}",MyMath.Add("500", "500"));
            Console.WriteLine("500+10500={0}",MyMath.Add("500", "10500"));

            Console.WriteLine(MyMath.Sub("234567892345678923456789", "123456781234567812345678"));

            Console.WriteLine(MyMath.Sub("12345", "12"));
            Console.WriteLine(MyMath.Sub("12", "12345"));

        }
    }
}
