using Sams2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sams2048.Tests
{
    [TestClass]
    public class GameResultTests
    {
        [TestMethod]
        public void GameIsWonTest()
        {
            //Arrange
            Game game = new();
            game.GameBoard[0, 0] = 2048;

            //Act
            bool gameIsComplete = game.CheckIfGameIsComplete();

            //Assert
            Assert.IsTrue(gameIsComplete);
        }

        [TestMethod]
        public void GameIsNotWonYetTest()
        {
            //Arrange
            Game game = new();
            game.GameBoard[0, 0] = 1;

            //Act
            bool gameIsComplete = game.CheckIfGameIsComplete();

            //Assert
            Assert.IsFalse(gameIsComplete);
        }

    }
}