namespace _2048.Logic
{
    public class Game
    {
        public Game(int x = 5, int y = 5)
        {
            GameBoard = new int[x, y];
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
    }
}