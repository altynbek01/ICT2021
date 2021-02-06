using System;

namespace lab0_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            int clown;
            while(num != 0) {
                if (num % 2 == 0)
                {
                    clown = num;
                    num /= 2;
                    count++;
                    Console.WriteLine("Step"+ count + " " + clown + " is even; divide by 2 and obtain " + clown / 2);
                }

                else
                {
                    clown = num;
                    num = num - 1;
                    count++;
                    Console.WriteLine("Step" +count+ " " + clown + " is odd; subtract 1 and obtain " + (clown-1));
                }

            }
            Console.WriteLine(count);
        }
    }
}
