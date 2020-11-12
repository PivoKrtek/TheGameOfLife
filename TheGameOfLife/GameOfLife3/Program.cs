using System;

namespace GameOfLife3
{
    class Program
    {
        public static bool[,] List { get; set; }

        public static bool[,] List2 { get; set; }
        public static int XSize { get; set; }
        public static int YSize { get; set; }
        public static int Neighbour { get; set; }

        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 40);
            XSize = 50;
            YSize = 34;
            List = new bool[YSize, XSize];
            List2 = new bool[YSize, XSize];
            GetStartValue();
            Neighbour = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                PrintList();
                DecideDeadOrAlive();
                var temp = List;
                List = List2;
                List2 = temp;
                System.Threading.Thread.Sleep(100);
               
            }


        }
        private static void PrintList()
        {
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    if (List[y, x])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\u2588\u2588");
                    }
                    else
                    { Console.Write("  "); }
                }
                Console.WriteLine();
            }
        }
        private static void GetStartValue()
        {
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    List[y, x] = RandomDeadOrAlive();
                }
            }
        }

        private static void DecideDeadOrAlive()
        {
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    Neighbour = 0;

                    for (int y2 = (y - 1); y2 < (y + 2); y2++)
                    {
                        if (y2 < 0 || y2 >= YSize) continue;
                        for (int x2 = (x - 1); x2 < (x + 2); x2++)
                        {
                            if (x2 < 0 || x2 >= XSize) continue;

                            if (List[y2, x2])
                            { Neighbour++; }
                        }
                    }

                    if (List[y, x])

                    {
                        Neighbour--;
                        if (Neighbour == 2 || Neighbour == 3)
                        { List2[y, x] = true; }
                        else
                        { List2[y, x] = false; }
                    }
                    else
                    {
                        if (Neighbour == 3)
                        { List2[y, x] = true; }
                        else
                        { List2[y, x] = false; }
                    }
                }
            }
            
        }

        public static bool RandomDeadOrAlive()
        {
            Random random = new Random();
            int number = random.Next(1, 3);
            if (number == 1)
            {
                return true;
            }
            return false;
        }
    }
}
