using Sams2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sams2048.Tests
{
    [TestClass]
    public class GameMovementUpTests
    {
        [TestMethod]
        public void MoveUpToMergeTest()
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
        public void MoveUpToNotMergeTest()
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
|8|16|16|128|
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
|2|4|8|16|
---------
|4|8|4|32|
---------
|8|16|16|128|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

        [TestMethod]
        public void SlideUpToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|0|0|0|1|
---------
|0|0|1|0|
---------
|0|1|2|4|
---------
|1|2|4|8|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesUp();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|1|1|1|
---------
|0|2|2|4|
---------
|0|0|4|8|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveUpWithMultipleMergesTest()
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
|4|8|16|32|
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
|8|8|8|16|
---------
|0|8|32|64|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

    }
}