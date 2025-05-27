using System;

namespace GameOfLifeApp
{
    class Grid
    {
        private int Width { get; }
        private int Height { get; }
        private Cell[,] Cells;
        private Cell[,] NextCells;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Height, Width];
            NextCells = new Cell[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells[y, x] = new Cell(false);
                    NextCells[y, x] = new Cell(false);
                }
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void SetCellAlive(int x, int y, bool alive)
        {
            if (IsInBounds(x, y))
                Cells[y, x].IsAlive = alive;
        }
        
        public bool IsCellAlive(int x, int y)
        {
            return Cells[y, x].IsAlive;
        }

        public void Display()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    Console.Write(Cells[y, x].IsAlive ? '0' : '-');
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Update()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int neighbors = CountAliveNeighbors(y, x);
                    bool shouldLive = Cells[y, x].IsAlive
                        ? neighbors == 2 || neighbors == 3
                        : neighbors == 3;

                    NextCells[y, x].IsAlive = shouldLive;
                }
            }

            // Swap grids
            var temp = Cells;
            Cells = NextCells;
            NextCells = temp;
        }

        private int CountAliveNeighbors(int y, int x)
        {
            int count = 0;
            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dy == 0 && dx == 0)
                        continue;

                    int ny = y + dy;
                    int nx = x + dx;

                    if (IsInBounds(nx, ny) && Cells[ny, nx].IsAlive)
                        count++;
                }
            }
            return count;
        }
    }
}
