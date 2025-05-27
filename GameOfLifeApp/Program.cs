using System;

namespace GameOfLifeApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter grid width and height:");
            string[] dimensions = Console.ReadLine().Split();
            int width = int.Parse(dimensions[0]);
            int height = int.Parse(dimensions[1]);

            Game game = new Game(width, height);
            game.Initialise();
            Console.Clear();

            Console.WriteLine("Initial State:");
            game.Display();

            game.Update();
            Console.WriteLine("Next Generation:");
            game.Display();
        }
    }
}
