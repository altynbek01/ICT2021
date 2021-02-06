using System;

namespace lab0
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(count + array[i] + " ");
                count=array[i]+count;
            }


        }

    }
}

