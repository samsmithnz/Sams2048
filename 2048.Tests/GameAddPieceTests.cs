using _2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class GameAddPieceTests
    {
        [TestMethod]
        public void AddPieceTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|2|0|0|0|
---------
|4|0|0|0|
---------
|8|0|0|0|
---------
";
            Game game = new(initialBoard);

            //Act
            game.AddNewPiece();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|2|0|0|0|
---------
|4|0|0|1|
---------
|8|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

        //[TestMethod]
        //public void GameIsNotWonYetTest()
        //{
        //    //Arrange
        //    Game game = new();
        //    game.GameBoard[0, 0] = 1;

        //    //Act
        //    bool gameIsComplete = game.CheckIfGameIsComplete();

        //    //Assert
        //    Assert.IsFalse(gameIsComplete);
        //}

    }
}