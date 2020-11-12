using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfLife
{
    class Program
    {
        public static int YSize { get; set; }
        public static int XSize { get; set; }
        public static List<Cell> ListOfCells { get; set; }

        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 40);
            Console.OutputEncoding = Encoding.Unicode;
            YSize = 34;
            XSize = 50;
            ListOfCells = Cell.CreateCells();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                PrintOutCells();
                ListOfCells = CheckEachSquareWillStayDeadOrAlive();
                System.Threading.Thread.Sleep(40);
                

            }


        }

        static void PrintOutCells()
        {
            for (int y = 1; y <= Program.YSize; y++)
            {
                for (int x = 1; x <= Program.XSize; x++)
                {
                    var c1 = ListOfCells
                        .Where(c => c.XPosition == x && c.YPosition == y)
                        .Select(c => c.Alive)
                        .ToList();
                    if (c1[0])
                    { Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\u2588\u2588");
                        
                    }
                    else
                    { //Console.Write("\u25A1"); 
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
        static List<Cell> CheckEachSquareWillStayDeadOrAlive()
        {
            List<Cell> newListCells = new List<Cell>();
            for (int y = 1; y <= Program.YSize; y++)
            {
                for (int x = 1; x <= Program.XSize; x++)
                {
                    var c1 = ListOfCells
                        .Where(c => c.XPosition == x && c.YPosition == y)
                        .ToList();

                    var c2 = ListOfCells
                        .Where(c => Cell.CheckIfSquaresAroundIsAlive(y, x, c))
                        .ToList();

                    bool alive = Cell.DecideDeadOrAlive(c1[0].Alive, c2.Count());

                    newListCells.Add(new Cell(y, x, alive));
                }
            }
            return newListCells;
        }
    }
}
