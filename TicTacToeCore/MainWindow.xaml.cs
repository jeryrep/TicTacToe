using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe.WPF
{
    public partial class MainWindow : Window
    {
        private bool _start = true;
        private readonly Dictionary<int, Canvas> _canvases;
        private GameController _gameController;

        public MainWindow()
        {
            InitializeComponent();
            _canvases = new Dictionary<int, Canvas>
            {
                {0, Can0},
                {1, Can1},
                {2, Can2},
                {3, Can3},
                {4, Can4},
                {5, Can5},
                {6, Can6},
                {7, Can7},
                {8, Can8}
            };
            _gameController =
                new GameController(_canvases, Difficulty.SelectedIndex);
        }

        private void Box0_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(0);
        }

        private void Box1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(1);
        }

        private void Box2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(2);
        }

        private void Box3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(3);
        }

        private void Box4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(4);
        }

        private void Box5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(5);
        }

        private void Box6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(6);
        }

        private void Box7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(7);
        }

        private void Box8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _gameController.PerformAction(8);
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            _gameController.ResetGame();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_start)
                _start = false;
            else
            {
                _gameController.ResetGame();
                _gameController = new GameController(_canvases, Difficulty.SelectedIndex);
            }
        }
    }
}