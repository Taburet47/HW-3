using System;
using MazeLibrary;
using MazeLibrary.Interfaces;
using MazeLibrary.WallGeneration;
namespace MazeDrawer
{
    class Program
    {
        public static WallGenerationInterface DivisionMethod { get; private set; }

        static void Main(string[] args)
        {
            Maze maze = new Maze(7,16);
            //Maze maze = new Maze(7, 16);
            DivisionMethod = new DivisionMethod();
            var Cells = DivisionMethod.GenerateMaze(7, 16);
            //var Cells = DivisionMethod.GenerateMaze(7, 16);
            maze.Cells = Cells;
            var instructions = " \n";

            var key = new ConsoleKeyInfo();
            Console.WriteLine(instructions + Drawer.Create(maze));
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            maze.TryToStep(Direction.Up);
                            break;
                        }

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        {
                            maze.TryToStep(Direction.Left);
                            break;
                        }

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        {
                            maze.TryToStep(Direction.Right);
                            break;
                        }

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            maze.TryToStep(Direction.Down);
                            break;
                        }
                }

                Console.WriteLine(instructions + Drawer.Create(maze));
            }
        }
    }
}
