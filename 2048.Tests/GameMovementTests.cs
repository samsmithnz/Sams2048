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
        public void MoveDownToMerge1To2Test()
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
            game.MovePiecesDown();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|0|0|0|0|
---------
|2|2|4|8|
---------
|4|8|8|16|
---------
|8|8|32|64|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveDownToMergeNoneTest()
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
            game.MovePiecesDown();
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
        public void MoveRightToMerge1To2Test()
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
            game.MovePiecesRight();
            string gameBoardCurrent = game.ToString();

            //Assert
            string gameBoardExpected = @"
---------
|1|2|4|8|
---------
|1|4|8|16|
---------
|0|8|16|32|
---------
|0|16|16|32|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveRightToMergeNoneTest()
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
        public void MoveLeftToMerge1To2Test()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|2|2|4|8|
---------
|4|8|16|16|
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
|4|4|8|0|
---------
|4|8|32|0|
---------
|16|32|64|0|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }


        [TestMethod]
        public void MoveLeftToMergeNoneTest()
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

    }
}