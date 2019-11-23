using NUnit.Framework;
using MazeLibrary.Cells;
using System;

namespace MazeLibrary.Tests
{
    class PlayerTesting
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = Player.GetPlayer;
        }

        [Test]
        public void IsPlayerSingleInGame()
        {
            Assert.AreEqual(_player, Player.GetPlayer);
        }

        [Test]
        public void CheckTryToStep()
        {
            Assert.Throws<Exception>(() =>_player.TryToStep());
        }
    }
}
