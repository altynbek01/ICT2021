using System;

namespace lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            string DefangIPaddr = Console.ReadLine();
            DefangIPaddr = DefangIPaddr.Replace(".", "[.]");
            Console.WriteLine(DefangIPaddr);

        }
    }
}
