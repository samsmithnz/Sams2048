using _2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class GameBoardToStringTests
    {
      
        [TestMethod]
        public void Game1ToStringTest()
        {
            //Arrange
            Game game = new();
            game.GameBoard[0, 0] = 1;

            //Act
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
-----------
|1|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void Game2048ToStringTest()
        {
            //Arrange
            Game game = new();
            game.GameBoard[0, 0] = 2048;

            //Act
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
-----------
|2048|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
|0|0|0|0|0|
-----------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }
    }
}