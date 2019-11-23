using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class ExitTesting
    {
        Exit exit;

        [SetUp]
        public void Setup()
        {
            exit = new Exit(5,5);
        }

        [Test]
        public void CheckTryToStep()
        {
            Assert.IsTrue(exit.TryToStep());
        }

    }
}
