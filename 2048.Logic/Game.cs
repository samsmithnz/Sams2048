using System.Numerics;
using System.Text;

namespace _2048.Logic
{
    public class Game
    {
        public Game(int x = 4, int y = 4)
        {
            GameBoard = new int[x, y];
        }

        //Read the board from a string
        public Game(string board, int x = 4, int y = 4)
        {
            GameBoard = new int[x, y];

            string[] lines = board.Split(Environment.NewLine);
            int currentX = 0;
            int currentY;
            for (int i = 0; i < lines.Length; i++)
            {
                currentY = 0;
                if (string.IsNullOrEmpty(lines[i]) == false && lines[i].StartsWith('-') != true)
                {
                    string[] cols = lines[i].Split('|');
                    for (int j = 0; j < cols.Length; j++)
                    {
                        if (int.TryParse(cols[j].ToString(), out int result) == true)
                        {
                            GameBoard[currentX, currentY] = result;
                            currentY++;
                        }
                    }
                    currentX++;
                }
            }
        }

        public int[,] GameBoard { get; set; }

        public bool CheckIfGameIsComplete()
        {
            int xLength = GameBoard.GetLength(0);
            int yLength = GameBoard.GetLength(1);

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (GameBoard[x, y] == 2048)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void MovePiecesUp()
        {
            GameMovement gameMovement = new(GameBoard);
            gameMovement.MovePiecesUp();
        }

        public void MovePiecesDown()
        {
            GameMovement gameMovement = new(GameBoard);
            gameMovement.MovePiecesDown();
        }

        public void MovePiecesLeft()
        {
            GameMovement gameMovement = new(GameBoard);
            gameMovement.MovePiecesLeft();
        }

        public void MovePiecesRight()
        {
            GameMovement gameMovement = new(GameBoard);
            gameMovement.MovePiecesRight();
        }

        public void AddNewPiece()
        {
            int xLength = GameBoard.GetLength(0);
            int yLength = GameBoard.GetLength(1);
            List<Vector2> openSpots = new();
            //Find all open squares
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (GameBoard[x, y] == 0)
                    {
                        openSpots.Add(new Vector2(x, y));
                    }
                }
            }
            //Get a random number based on the number of open spots
            if (openSpots.Count > 0)
            {
                int randomIndex = RandomNumbers.GenerateRandomNumber(0, openSpots.Count - 1, 0);
                GameBoard[(int)openSpots[randomIndex].X, (int)openSpots[randomIndex].Y] = 1;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            int xLength = GameBoard.GetLength(0);
            int yLength = GameBoard.GetLength(1);
            sb.Append(Environment.NewLine);
            sb.Append(AddDividingLine(yLength));
            for (int x = 0; x < xLength; x++)
            {
                sb.Append('|');
                for (int y = 0; y < yLength; y++)
                {
                    sb.Append(GameBoard[x, y]);
                    sb.Append('|');
                }
                sb.Append(Environment.NewLine);
                sb.Append(AddDividingLine(yLength));
            }
            return sb.ToString();
        }

        private static string AddDividingLine(int length)
        {
            StringBuilder sb = new();
            for (int y = 0; y < length; y++)
            {
                sb.Append("--");
            }
            sb.Append('-');
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}