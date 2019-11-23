using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests
{
    public class CoordinatesTesting
    {
        Coordinates coord;
        int x = 5, y = 5;

        [SetUp]
        public void Setup()
        {
            coord = new Coordinates(x, y);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(coord.X, x);
            Assert.AreEqual(coord.Y, y);
        }
    }
}