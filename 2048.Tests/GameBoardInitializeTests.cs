using _2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class GameBoardInitializeTests
    {
      
        [TestMethod]
        public void Game1InitializationTest()
        {
            //Arrange
           string initialBoard = @"
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
            Game game = new(initialBoard);
            game.GameBoard[0, 0] = 1;

            //Act
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
-----------
|1|2|4|8|16|
-----------
|2|0|0|0|0|
-----------
|4|0|0|0|0|
-----------
|8|0|0|0|0|
-----------
|16|0|0|0|0|
-----------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void Game2048InitializationTest()
        {
            //Arrange
            string initialBoard = @"
-----------
|1|2|4|8|16|
-----------
|2|0|0|0|0|
-----------
|4|0|0|0|0|
-----------
|8|0|0|0|0|
-----------
|16|0|0|0|0|
-----------
";
            Game game = new(initialBoard);
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
|0|0|0|1|2|
-----------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }
    }
}