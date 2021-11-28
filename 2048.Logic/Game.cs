using System.Text;

namespace _2048.Logic
{
    public class Game
    {
        public Game(int x = 4, int y = 4)
        {
            GameBoard = new int[x, y];
        }
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
            int xLength = GameBoard.GetLength(0);
            int yLength = GameBoard.GetLength(1);

            //for (int x = 0; x < xLength; x++)
            //{
            //    if (GameBoard[x, 0] > 0 && GameBoard[x, 0] == GameBoard[x, 1])
            //    {
            //        GameBoard[x, 0] = GameBoard[x, 0] * 2;
            //        GameBoard[x, 1] = GameBoard[x, 2];
            //        GameBoard[x, 2] = GameBoard[x, 3];
            //        GameBoard[x, 3] = GameBoard[x, 4];
            //        GameBoard[x, 4] = 0;
            //    }
            //    if (GameBoard[x, 1] > 0 && GameBoard[x, 1] == GameBoard[x, 2])
            //    {
            //        GameBoard[x, 1] = GameBoard[x, 1] * 2;
            //        GameBoard[x, 2] = GameBoard[x, 3];
            //        GameBoard[x, 3] = GameBoard[x, 4];
            //        GameBoard[x, 4] = 0;
            //    }
            //    if (GameBoard[x, 2] > 0 && GameBoard[x, 2] == GameBoard[x, 3])
            //    {
            //        GameBoard[x, 2] = GameBoard[x, 2] * 2;
            //        GameBoard[x, 3] = GameBoard[x, 4];
            //        GameBoard[x, 4] = 0;
            //    }
            //    if (GameBoard[x, 3] > 0 && GameBoard[x, 3] == GameBoard[x, 4])
            //    {
            //        GameBoard[x, 3] = GameBoard[x, 3] * 2;
            //        GameBoard[x, 4] = 0;
            //    }
            //}
            for (int y = 0; y < yLength; y++)
            {
                if (GameBoard[0, y] > 0 && GameBoard[0, y] == GameBoard[1, y])
                {
                    GameBoard[0, y] = GameBoard[0, y] * 2;
                    MoveRowUpFromPosition(1, y);
                }
                if (GameBoard[1, y] > 0 && GameBoard[1, y] == GameBoard[2, y])
                {
                    GameBoard[1, y] = GameBoard[1, y] * 2;
                    MoveRowUpFromPosition(2, y);
                }
                if (GameBoard[2, y] > 0 && GameBoard[2, y] == GameBoard[3, y])
                {
                    GameBoard[2, y] = GameBoard[2, y] * 2;
                    MoveRowUpFromPosition(3, y);
                }
            }
        }

        private void MoveRowUpFromPosition(int xStart, int yStart)
        {
            for (int x = xStart; x < 3; x++)
            {
                GameBoard[x, yStart] = GameBoard[x + 1, yStart];
            }
            GameBoard[3, yStart] = 0;
        }

        //public void MovePiecesDown()
        //{

        //}

        //public void MovePiecesLeft()
        //{

        //}

        //public void MovePiecesRight()
        //{

        //}

        //public void AddNewPiece()
        //{

        //}

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

        private string AddDividingLine(int length)
        {
            StringBuilder sb = new StringBuilder();
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