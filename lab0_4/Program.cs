using System;

namespace lab0_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            string[] word1 = new string[size];
            string[] word2 = new string[size];
            string full_word1="", full_word2="";
            for (int i = 0; i < word1.Length; i++)
            {
                word1[i] = Console.ReadLine();
            }
            for (int i = 0; i < word2.Length; i++)
            {
                word2[i] = Console.ReadLine();
            }

            for (int i = 0; i < word1.Length; i++)
            {
                full_word1=string.Concat(full_word1,word1[i]);
            }

            for (int i = 0; i < word2.Length; i++)
            {
                full_word2 = string.Concat(full_word2, word2[i]);
            }

            if(full_word1==full_word2)
            { Console.WriteLine("true"); }
            else
            {
                Console.WriteLine("false");
            }
    

        }
    }
}
