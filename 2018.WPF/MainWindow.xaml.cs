using _2048.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2018.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game _game { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _game = new();
            _game.AddNewPiece();
            UpdateBoard();
        }

        private void btnUp_Clicked(object sender, RoutedEventArgs e)
        {
            txtBefore.Text = _game.ToString();
            _game.MovePiecesUp();
            _game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = _game.ToString();
        }

        private void btnDown_Clicked(object sender, RoutedEventArgs e)
        {
            txtBefore.Text = _game.ToString();
            _game.MovePiecesDown();
            _game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = _game.ToString();
        }

        private void btnRight_Clicked(object sender, RoutedEventArgs e)
        {
            txtBefore.Text = _game.ToString();
            _game.MovePiecesRight();
            _game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = _game.ToString();
        }

        private void btnLeft_Clicked(object sender, RoutedEventArgs e)
        {
            txtBefore.Text = _game.ToString();
            _game.MovePiecesLeft();
            _game.AddNewPiece();
            UpdateBoard();
            txtAfter.Text = _game.ToString();
        }

        private void UpdateBoard()
        {
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    Button button = (Button)this.FindName("btn_x" + x.ToString() + "y" + y.ToString());
                    button.Content = _game.GameBoard[x, y];
                    button.Background = new SolidColorBrush(GetColor(_game.GameBoard[x, y]));
                }
            }
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
    }
}
