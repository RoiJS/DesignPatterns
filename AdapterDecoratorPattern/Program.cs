using System;
using System.Text;
using static System.Console;

namespace AdapterDecoratorPattern
{
    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.sb.Append(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, 
            string s)
        {
            msb.sb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    class Program
    {
        public 
        static void Main(string[] args)
        {
            MyStringBuilder s = "hello ";
            s += "world";

            WriteLine(s);
        }
    }
}
