using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToeCore
{
    public partial class MainWindow : Window
    {
        private BoardController _boardController;
        private readonly Dictionary<int, Canvas> _canvases;
        private bool _start = true;

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
            _boardController = new BoardController(Difficulty.SelectedIndex, _canvases);
        }

        private void Box0_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(0);
        }

        private void Box1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(1);
        }

        private void Box2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(2);
        }

        private void Box3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(3);
        }

        private void Box4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(4);
        }

        private void Box5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(5);
        }

        private void Box6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(6);
        }

        private void Box7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(7);
        }

        private void Box8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _boardController.ProcessClick(8);
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            _boardController.ClearBoard();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_start)
                _start = false;
            else
            {
                _boardController.ClearBoard();
                _boardController = new BoardController(Difficulty.SelectedIndex, _canvases);
            }
        }
    }
}