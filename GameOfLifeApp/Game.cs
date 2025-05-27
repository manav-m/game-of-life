using System;

namespace GameOfLifeApp
{
    class Game
    {
        private Grid Grid;

        public Game(int width, int height)
        {
            Grid = new Grid(width, height);
        }

        public void Initialise()
        {
            Console.WriteLine("Enter live cell coordinates (x y), one per line. End input with empty line:");
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                string[] parts = line.Trim().Split();
                if (parts.Length != 2)
                    continue;

                if (int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    if (Grid.IsInBounds(x, y))
                        Grid.SetCellAlive(x, y, true);
                    else
                        Console.WriteLine($"Coordinates ({x}, {y}) are out of bounds");
                }
            }
        }

        public void Display()
        {
            Grid.Display();
        }

        public void Update()
        {
            Grid.Update();
        }
    }
}
