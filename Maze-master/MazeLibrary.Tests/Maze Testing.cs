using NUnit.Framework;
using MazeLibrary;
using MazeLibrary.Interfaces;
using MazeLibrary.Cells;


namespace MazeLibrary.Tests.Cells
{
    public class MazeTesting
    {
        private Player hero;
        public Maze maze;
        int x = 5, y = 5;

        [SetUp]
        public void Setup()
        {
            maze = new Maze(x, y);
            hero = Player.GetPlayer;
        }

        [Test]
        public void TryToStepTesting()
        {
            maze.TryToStep(Direction.Down);
            Assert.AreEqual(2, hero.Coordinates.Y);
            maze.TryToStep(Direction.Right);
            Assert.AreEqual(2, hero.Coordinates.X);
            maze.TryToStep(Direction.Up);
            Assert.AreEqual(1, hero.Coordinates.Y);
            maze.TryToStep(Direction.Left);
            Assert.AreEqual(1, hero.Coordinates.X);
        }
        [Test]
        public void MazeConstructorChecking()
        {
            Assert.AreEqual(x, maze.Width);
            Assert.AreEqual(y, maze.Height);
        }
    }
}
