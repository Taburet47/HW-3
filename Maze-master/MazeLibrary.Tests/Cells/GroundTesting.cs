using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class GroundTesting
    {
        Ground ground;

        [SetUp]
        public void Setup()
        {
            ground = new Ground(5, 5);
        }

        [Test]
        public void CheckTryToStep()
        {
            Assert.IsTrue(ground.TryToStep());

        }
    }
}
