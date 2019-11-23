using NUnit.Framework;
using MazeLibrary;
using MazeLibrary.Interfaces;
using MazeLibrary.WallGeneration;
using System;
namespace MazeLibrary.Tests
{
    class ProgramTesting
    {
        public static WallGenerationInterface DivisionMethod { get; private set; }
        private Player hero;
        public Maze maze;
        public Direction direction;
        [SetUp]
        public void Setup()
        {
            maze = new Maze(7, 16);
            DivisionMethod = new DivisionMethod();
            var Cells = DivisionMethod.GenerateMaze(7, 16);
            maze.Cells = Cells;
            hero = Player.GetPlayer;
        }
        [Test]
        public void GainExitTesting()
        {
            while (hero.Coordinates.X != 6 || hero.Coordinates.Y != 1)
            {
                maze[hero.Coordinates.X, hero.Coordinates.Y].Checked = true;
                if (maze[hero.Coordinates.X - 1, hero.Coordinates.Y].TryToStep() == true && maze[hero.Coordinates.X - 1, hero.Coordinates.Y].Checked == false)
                {
                    hero.Coordinates = maze[hero.Coordinates.X - 1, hero.Coordinates.Y].Coordinates;
                    direction = Direction.Left;
                }
                else if (maze[hero.Coordinates.X, hero.Coordinates.Y - 1].TryToStep() == true && maze[hero.Coordinates.X, hero.Coordinates.Y - 1].Checked == false)
                {
                    hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y - 1].Coordinates;
                    direction = Direction.Down;
                }
                else if (maze[hero.Coordinates.X + 1, hero.Coordinates.Y].TryToStep() == true && maze[hero.Coordinates.X + 1, hero.Coordinates.Y].Checked == false)
                {
                    hero.Coordinates = maze[hero.Coordinates.X + 1, hero.Coordinates.Y].Coordinates;
                    direction = Direction.Right;
                }
                else if (maze[hero.Coordinates.X, hero.Coordinates.Y + 1].TryToStep() == true && maze[hero.Coordinates.X, hero.Coordinates.Y + 1].Checked == false)
                {
                    hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y + 1].Coordinates;
                    direction = Direction.Up;
                }
                else for (; ;)
                    {
                        if (maze[hero.Coordinates.X - 1, hero.Coordinates.Y].TryToStep() == true && maze[hero.Coordinates.X - 1, hero.Coordinates.Y].Checked == false)
                        {
                            hero.Coordinates = maze[hero.Coordinates.X - 1, hero.Coordinates.Y].Coordinates;
                            direction = Direction.Left;
                            break;
                        }
                        else if (maze[hero.Coordinates.X, hero.Coordinates.Y - 1].TryToStep() == true && maze[hero.Coordinates.X, hero.Coordinates.Y - 1].Checked == false)
                        {
                            hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y - 1].Coordinates;
                            direction = Direction.Down;
                            break;
                        }
                        else if (maze[hero.Coordinates.X + 1, hero.Coordinates.Y].TryToStep() == true && maze[hero.Coordinates.X + 1, hero.Coordinates.Y].Checked == false)
                        {
                            hero.Coordinates = maze[hero.Coordinates.X + 1, hero.Coordinates.Y].Coordinates;
                            direction = Direction.Right;
                            break;
                        }
                        else if (maze[hero.Coordinates.X, hero.Coordinates.Y + 1].TryToStep() == true && maze[hero.Coordinates.X, hero.Coordinates.Y + 1].Checked == false)
                        {
                            hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y + 1].Coordinates;
                            direction = Direction.Up;
                            break;
                        }
                        else
                        {
                            if (direction==Direction.Down) hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y-1].Coordinates;
                            else if (direction == Direction.Up) hero.Coordinates = maze[hero.Coordinates.X, hero.Coordinates.Y + 1].Coordinates;
                            else if (direction == Direction.Right) hero.Coordinates = maze[hero.Coordinates.X-1, hero.Coordinates.Y].Coordinates;
                            else if (direction == Direction.Left) hero.Coordinates = maze[hero.Coordinates.X+1, hero.Coordinates.Y].Coordinates;
                        }
                    }
            }
            Assert.AreEqual(maze[6,1].Coordinates, hero.Coordinates);
        }
    }
}

