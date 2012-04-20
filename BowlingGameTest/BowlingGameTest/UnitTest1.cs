using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Game;

namespace BowlingGameTest
{
    [TestClass]
    public class UnitTest1
    {
        private Game game = new Game();


        private void RollMany(int times, int score)
        {
            for (int loop = 0; loop < times; ++loop)
            {
                game.roll(score);
            }
        }
        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game.roll(3);
            game.roll(4);

            RollMany(16, 0);

            Assert.AreEqual(game.score(), 24);
        }
        [TestMethod]
        public void TestOneSpareStrike()
        {
            RollStrike();
            RollSpare();
            game.roll(4);

            RollMany(15, 0);

            Assert.AreEqual(game.score(), 38);
        }
        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.roll(3);
            game.roll(4);

            RollMany(16, 0);

            Assert.AreEqual(game.score(), 20);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);

            Assert.AreEqual(game.score(), 300);
        }
        private void RollStrike()
        {
            game.roll(10);
        }

        private void RollSpare()
        {
            game.roll(5);
            game.roll(5);
        }

        [TestMethod]
        public void Test20Zero()
        {
            RollMany(20, 0);
            Assert.AreEqual(game.score(), 0);
        }

        [TestMethod]
        public void Test20One()
        {
            RollMany(20, 1);
            Assert.AreEqual(game.score(), 20);
        }
    }
}
