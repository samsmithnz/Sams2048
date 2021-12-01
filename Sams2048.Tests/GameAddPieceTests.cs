using Sams2048.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sams2048.Tests
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
        [TestMethod]
        public void AddPieceWithNoSpacesLeftTest()
        {
            //Arrange
            string initialBoard = @"
---------
|1|2|4|8|
---------
|1|2|4|8|
---------
|1|2|4|8|
---------
|1|2|4|8|
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
|1|2|4|8|
---------
|1|2|4|8|
---------
|1|2|4|8|
---------
";
            Assert.AreEqual(gameBoardExpected, gameBoardCurrent);
        }

        [TestMethod]
        public void Add16PiecesTest()
        {
            //Arrange
            string initialBoard = @"
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
";
            Game game = new(initialBoard);

            //Act
            game.AddNewPiece();
            string gameBoardCurrent1 = game.ToString();

            //Assert
            string gameBoardExpected1 = @"
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|0|0|1|0|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected1, gameBoardCurrent1);

            //Act 2
            game.AddNewPiece();
            string gameBoardCurrent2 = game.ToString();

            //Assert 2
            string gameBoardExpected2 = @"
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|0|0|1|1|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected2, gameBoardCurrent2);

            //Act 3
            game.AddNewPiece();
            string gameBoardCurrent3 = game.ToString();

            //Assert 3
            string gameBoardExpected3 = @"
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|0|1|1|1|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected3, gameBoardCurrent3);

            //Act 4
            game.AddNewPiece();
            string gameBoardCurrent4 = game.ToString();

            //Assert 4
            string gameBoardExpected4 = @"
---------
|0|0|0|0|
---------
|0|0|0|0|
---------
|1|1|1|1|
---------
|0|0|0|0|
---------
";
            Assert.AreEqual(gameBoardExpected4, gameBoardCurrent4);
        }
    }
}