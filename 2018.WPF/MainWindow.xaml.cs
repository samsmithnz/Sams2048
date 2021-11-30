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
            _game.MovePiecesUp();
            _game.AddNewPiece();
            UpdateBoard();
        }

        private void btnDown_Clicked(object sender, RoutedEventArgs e)
        {
            _game.MovePiecesDown();
            _game.AddNewPiece();
            UpdateBoard();
        }

        private void btnRight_Clicked(object sender, RoutedEventArgs e)
        {
            _game.MovePiecesRight();
            _game.AddNewPiece();
            UpdateBoard();
        }

        private void btnLeft_Clicked(object sender, RoutedEventArgs e)
        {
            _game.MovePiecesLeft();
            _game.AddNewPiece();
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    Button button = (Button)this.FindName("btn_x" + x.ToString() + "y" + y.ToString());
                    button.Content = _game.GameBoard[x, y];
                }
            }
        }
    }
}
