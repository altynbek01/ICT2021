using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    class Layer
    {
        public DirectoryInfo dir
        {
            get;
            set;
        }
        public int pos
        {
            get;
            set;
        }
        public List<FileSystemInfo> content
        {
            get;
            set;
        }

        public Layer(DirectoryInfo dir, int pos)
        {
            this.dir = dir;
            this.pos = pos;
            this.content = new List<FileSystemInfo>();


            content.AddRange(this.dir.GetDirectories());
            content.AddRange(this.dir.GetFiles());
        }

        public void PrintInfo()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            int cnt = 0;
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (cnt == pos)
                {   
                    Console.BackgroundColor = ConsoleColor.Cyan;
  
                    DirectoryInfo dir = (DirectoryInfo)content[pos];
                    Console.WriteLine("             " + DirSize(dir) + " Bytes");

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(d.Name);
                cnt++;
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            foreach (FileInfo f in dir.GetFiles())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    FileInfo file = (FileInfo)content[pos];
                    Console.WriteLine("             " + file.Length + " Bytes");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(f.Name);
                cnt++;
            }
        }
        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;

            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public FileSystemInfo GetCurrentObject()
        {
            return content[pos];
        }

        public void SetNewPosition(int d)
        {
            if (d > 0)
            {
                pos++;
            }
            else
            {
                pos--;
            }
            if (pos >= content.Count)
            {
                pos = 0;
            }
            else if (pos < 0)
            {
                pos = content.Count - 1;
            }
        }
        public void GoBegin()
        {
            pos = 0;
        }

        public void GoEnd()
        {
            pos = content.Count - 1;
        }

        /* public static long DirSize(DirectoryInfo d)
     {
         long size = 0;
         // Add file sizes.
         FileInfo[] fis = d.GetFiles();
         foreach (FileInfo fi in fis)
         {
             size += fi.Length;
         }
         // Add subdirectory sizes.
         DirectoryInfo[] dis = d.GetDirectories();
         foreach (DirectoryInfo di in dis)
         {
             size += DirSize(di);
         }
         return size;

     }*/
    }
    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void F3()
        {

            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(new DirectoryInfo(@"C:\Users\Altynbek\Desktop\WEB"), 0));

            bool escape = false;

            while (!escape)
            {
                Console.Clear();

                history.Peek().PrintInfo();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (history.Peek().GetCurrentObject().GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(new Layer(history.Peek().GetCurrentObject() as DirectoryInfo, 0));
                        }
                        else if (history.Peek().GetCurrentObject().GetType() == typeof(FileInfo)) {

                            using (FileStream fs = new FileStream(history.Peek().GetCurrentObject().FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Black;

                                    Console.WriteLine(sr.ReadToEnd());
                                    Console.ReadLine();
                                }
                            }

                        }
                        break;
                    /*case ConsoleKey.Backspace:
                        DirectoryInfo d = history.Peek().GetCurrentObject() as DirectoryInfo;
                        Console.WriteLine(DirSize(d));
                        

                        break;*/
                    case ConsoleKey.UpArrow:
                        history.Peek().SetNewPosition(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SetNewPosition(1);
                        break;
                    case ConsoleKey.Escape:
                        history.Pop();
                        break;
                    case ConsoleKey.W:
                        history.Peek().GoBegin();
                        break;

                    case ConsoleKey.S:
                        history.Peek().GoEnd();
                        break;
                }
            }
        }

     

        private static void F2()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape) break;
                Console.WriteLine(consoleKeyInfo.KeyChar);
            }
        }

        private static void F1()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine(consoleKeyInfo);
        }
    }
}
   
