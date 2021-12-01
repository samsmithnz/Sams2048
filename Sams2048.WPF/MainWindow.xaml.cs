using Sams2048.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _2018.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Game = new();
            Game.AddNewPiece();
            UpdateBoard();
        }

        private void btnUp_Clicked(object sender, RoutedEventArgs e)
        {
            MoveUp();
        }

        private void btnDown_Clicked(object sender, RoutedEventArgs e)
        {
            MoveDown();
        }

        private void btnRight_Clicked(object sender, RoutedEventArgs e)
        {
            MoveRight();
        }

        private void btnLeft_Clicked(object sender, RoutedEventArgs e)
        {
            MoveLeft();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) // The Arrow-Up key
            {
                MoveUp();
            }
            else if (e.Key == Key.Down) // The Arrow-Down key
            {
                MoveDown();
            }
            else if (e.Key == Key.Right) // The Arrow-Right key
            {
                MoveRight();
            }
            else if (e.Key == Key.Left) // The Arrow-Left key
            {
                MoveLeft();
            }
        }

        private void MoveUp()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesUp();
            Game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = Game.ToString();
        }

        private void MoveDown()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesDown();
            Game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = Game.ToString();
        }

        private void MoveRight()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesRight();
            Game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = Game.ToString();
        }

        private void MoveLeft()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesLeft();
            Game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = Game.ToString();
        }

        private void UpdateBoard()
        {
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    Button button = (Button)this.FindName("btn_x" + x.ToString() + "y" + y.ToString());
                    button.Content = Game.GameBoard[x, y];
                    button.Background = new SolidColorBrush(GetColor(Game.GameBoard[x, y]));
                }
            }

            bool complete = Game.CheckIfGameIsComplete();
            if (complete)
            {
                MessageBox.Show("Congratulations, you won!");
            }
            //else
            //{
            //    //Check if the game is stuck
            //    int zeroSquareCount = 0;
            //    for (int y = 0; y <= 3; y++)
            //    {
            //        for (int x = 0; x <= 3; x++)
            //        {
            //            if (Game.GameBoard[x, y] == 0)
            //            {
            //                zeroSquareCount++;
            //            }
            //        }
            //    }
            //    if (zeroSquareCount == 0)
            //    {
            //        MessageBox.Show("You lost! Restart, or use a cheat...");
            //    }
            //}
        }

        private Color GetColor(int value)
        {
            switch (value)
            {
                case 0: return Colors.White;
                case 1: return Colors.SkyBlue;
                case 2: return Colors.Blue;
                case 4: return Colors.Cyan;
                case 8: return Colors.DarkSeaGreen;
                case 16: return Colors.Green;
                case 32: return Colors.Gold;
                case 64: return Colors.Goldenrod;
                case 128: return Colors.Orange;
                case 256: return Colors.OrangeRed;
                case 512: return Colors.Red;
                case 1024: return Colors.Maroon;
                case 2048: return Colors.Purple;
                default: return Colors.White;
            }
        }

        private void btnCheatReorderPieces(object sender, RoutedEventArgs e)
        {
            //Extract all of the pieces into a list
            List<int> pieces = new();
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                        pieces.Add(Game.GameBoard[x, y]);
                }
            }
            //Order the list
            pieces.Sort();
            //Put the pieces back into the gameboard
            int i = 0;
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    Game.GameBoard[x, y] = pieces[i];
                    i++;
                }
            }
            //Update the game board
            UpdateBoard();
        }
    }
}
