using Sams2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sams2048.Tests
{
    [TestClass]
    public class GameMovementDownTests
    {

        [TestMethod]
        public void MoveDownToMergeTest()
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
        public void MoveDownToNotMergeTest()
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
        public void SlideDownToMergeTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|0|1|2|4|
---------
|0|0|1|0|
---------
|0|0|0|1|
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
|0|0|4|8|
---------
|0|2|2|4|
---------
|1|1|1|1|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

    }
}