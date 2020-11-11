using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameOfLife
{
    class Cell
    {
        public int YPosition { get; set; }
        public int XPosition { get; set; }
        public bool Alive { get; set; }

        public Cell(int ypos, int xpos)
        {
            YPosition = ypos;
            XPosition = xpos;
            Alive = RandomDeadOrAlive();
        }
        public Cell(int ypos, int xpos, bool alive)
        {
            YPosition = ypos;
            XPosition = xpos;
            Alive = alive;
        }

        private bool RandomDeadOrAlive()
        {
            Random random = new Random();
            int number = random.Next(1, 3);
            if (number == 1)
            {
                return true;
            }
            return false;
        }

        public static List<Cell> CreateCells()
        {
            List<Cell> listOfCells = new List<Cell>();
            for (int y = 1; y <= Program.YSize; y++)
            {
                for (int x = 1; x <= Program.XSize; x++)
                {
                    listOfCells.Add(new Cell(y, x));
                }
            }
            return listOfCells;
        }
        public static bool CheckIfSquaresAroundIsAlive(int y, int x, Cell cell)
        {
            if (y == cell.YPosition && x == cell.XPosition)
            { return false; }
            if ((cell.YPosition == y-1 || cell.YPosition == y || cell.YPosition == y+1) && (cell.XPosition == x-1 || cell.XPosition == x || cell.XPosition == x + 1))
            { return cell.Alive; }
            return false;
        }
        public static bool DecideDeadOrAlive(bool alive, int numberOfAliveSquaresAround)
        {
            if (alive)
            { return StayAlive(numberOfAliveSquaresAround); }

            return BecomeAlive(numberOfAliveSquaresAround);
        }

        private static bool BecomeAlive(int numberOfAliveSquaresAround)
        {
            if (numberOfAliveSquaresAround == 3)
            { return true; }
            return false;
        }

        private static bool StayAlive(int numberOfAliveSquaresAround)
        {
            if (numberOfAliveSquaresAround == 2 || numberOfAliveSquaresAround == 3)
            { return true; }
            return false;
        }
    }
}
