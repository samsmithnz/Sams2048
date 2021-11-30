using _2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class GameLeftMovementTests
    {

        [TestMethod]
        public void MoveLeftToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|2|4|8|8|
---------
|4|16|16|32|
---------
|8|8|32|64|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesLeft();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|2|4|16|0|
---------
|4|32|32|0|
---------
|16|32|64|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveLeftToNotMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|2|4|8|16|
---------
|4|8|4|32|
---------
|8|16|32|128|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesLeft();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|2|4|8|16|
---------
|4|8|4|32|
---------
|8|16|32|128|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

        [TestMethod]
        public void SlideLeftToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|0|0|0|1|
---------
|0|0|1|2|
---------
|0|1|2|4|
---------
|1|0|4|8|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesLeft();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|0|0|0|
---------
|1|2|0|0|
---------
|1|2|4|0|
---------
|1|4|8|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

    }
}