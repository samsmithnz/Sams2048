using _2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class GameMovementTests
    {
        [TestMethod]
        public void MoveUpToMerge1To2Test()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|1|4|8|16|
---------
|4|4|16|32|
---------
|8|8|16|32|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesUp();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|2|2|4|8|
---------
|4|8|8|16|
---------
|8|8|32|64|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveUpToMergeNoneTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|2|0|0|16|
---------
|4|0|0|32|
---------
|8|0|0|128|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesUp();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|2|0|0|16|
---------
|4|0|0|32|
---------
|8|0|0|128|
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