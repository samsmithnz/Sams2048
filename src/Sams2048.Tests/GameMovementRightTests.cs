using Sams2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sams2048.Tests
{
    [TestClass]
    public class GameMovementRightTests
    {
        [TestMethod]
        public void MoveRightToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|1|4|4|16|
---------
|4|4|16|32|
---------
|8|16|32|32|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesRight();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|0|1|8|16|
---------
|0|8|16|32|
---------
|0|8|16|64|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveRightToNotMergeTest()
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
            game.MovePiecesRight();
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
        public void SlideRightToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|0|0|0|
---------
|2|1|0|0|
---------
|4|2|1|0|
---------
|8|4|0|1|
---------
";
            Game game = new(initialBoard);

            //Act
            game.MovePiecesRight();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|0|0|0|1|
---------
|0|0|2|1|
---------
|0|4|2|1|
---------
|0|8|4|1|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


    }
}