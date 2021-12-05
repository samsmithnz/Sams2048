using Sams2048.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
            //            string initialBoard = @"
            //---------
            //|1024|2|4|8|
            //---------
            //|512|16|0|0|
            //---------
            //|256|32|0|0|
            //---------
            //|128|64|0|0|
            //---------
            //";
            //            Game = new(initialBoard);
            Game = new();
            Game.AddNewPiece();
            UpdateBoard(0, 0);
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
            UpdateBoard(1, 0);
            txtAfter.Text = Game.ToString();
        }

        private void MoveDown()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesDown();
            Game.AddNewPiece();
            UpdateBoard(-1, 0);
            txtAfter.Text = Game.ToString();
        }

        private void MoveRight()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesRight();
            Game.AddNewPiece();
            UpdateBoard(0, -1);
            txtAfter.Text = Game.ToString();
        }

        private void MoveLeft()
        {
            txtBefore.Text = Game.ToString();
            Game.MovePiecesLeft();
            Game.AddNewPiece();
            UpdateBoard(0, 1);
            txtAfter.Text = Game.ToString();
        }

        private void UpdateBoard(int xDirection, int yDirection)
        {
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    Button button = (Button)this.FindName("btn_x" + x.ToString() + "y" + y.ToString());
                    if (Game.GameBoard[x, y].ToString() != button.Content.ToString())
                    {
                        AnimateSquare(button, xDirection, yDirection);
                        button.Content = Game.GameBoard[x, y];
                        button.Background = new SolidColorBrush(GetColor(Game.GameBoard[x, y]));
                    }
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
                case 64: return Colors.Orange;
                case 128: return Colors.Red;
                case 256: return Colors.IndianRed;
                case 512: return Colors.Maroon;
                case 1024: return Colors.Purple;
                case 2048: return Colors.Pink;
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
            //reverse the order to put the biggest items in the top left
            pieces.Reverse();
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
            UpdateBoard(0, 0);
        }

        private void btnMergeTest(object sender, RoutedEventArgs e)
        {
            Thickness initialMargin = btn1.Margin;
            Thickness currentMargin = btn1.Margin;
            for (int i = 630; i <= 690; i++)
            {
                currentMargin.Left += 1;
                btn1.Margin = currentMargin;
                DoEvents();
                Task.Delay(50);
            }
            btn1.Margin = initialMargin;
        }

        private void AnimateSquare(Button piece, int x, int y)
        {
            Thickness initialMargin = piece.Margin;
            Thickness currentMargin = piece.Margin;
            //if (x > 0)
            //{
            //    //Moving down
            //    for (int i = 0; i < initialMargin.Bottom + 100; i++)
            //    {
            //        currentMargin.Bottom += 1;
            //        piece.Margin = currentMargin;
            //        DoEvents();
            //        Task.Delay(50);
            //    }
            //}
            //else if (x < 0)
            //{
            //    //Moving up
            //    for (int i = 0; i < initialMargin.Top + 100; i++)
            //    {
            //        currentMargin.Top += 1;
            //        piece.Margin = currentMargin;
            //        DoEvents();
            //        Task.Delay(50);
            //    }
            //}
            //else if (y > 0)
            //{
            //    //Moving left
            //    for (int i = 0; i < initialMargin.Left + 100; i++)
            //    {
            //        currentMargin.Left += 1;
            //        piece.Margin = currentMargin;
            //        DoEvents();
            //        Task.Delay(50);
            //    }
            //}
            //else if (y < 0)
            //{
            //    //Moving right
            //    for (int i = 0; i < initialMargin.Right + 100; i++)
            //    {
            //        currentMargin.Right += 1;
            //        piece.Margin = currentMargin;
            //        DoEvents();
            //        Task.Delay(50);
            //    }
            //}
            //piece.Margin = initialMargin;
        }

        private static void DoEvents()
        {
            DispatcherFrame? frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(
                    delegate (object f)
                    {
                        ((DispatcherFrame)f).Continue = false;
                        return null;
                    }), frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
