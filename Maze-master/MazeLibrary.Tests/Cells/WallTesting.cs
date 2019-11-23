using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class WallTessting
    {
        Wall wall;

        [SetUp]
        public void Setup()
        {
            wall = new Wall(5, 5);
        }

        [Test]
        public void CheckTryToStep()
        {
            Assert.IsFalse(wall.TryToStep());

        }
    }
}