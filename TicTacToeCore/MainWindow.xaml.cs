using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TicTacToeCore.Symbols;
using TicTacToeCore.TicTacToe;

namespace TicTacToeCore
{
    public partial class MainWindow : Window
    {
        private Board _board;
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
            _board = new Board();
        }

        private void MakeAiMove()
        {
            switch (Difficulty.SelectedIndex)
            {
                case 0:
                    _board.MakeEasyMove();
                    break;

                case 1:
                    _board.MakeMediumMove();
                    break;

                case 2:
                    _board.MakeImpossibleMove();
                    break;
            }
        }

        private static void ShowError()
        {
            MessageBox.Show("This cell is occupied. Select another one.", "Error");
        }

        private void GameOver()
        {
            MessageBox.Show("Game over!", "Message");
            ResetGame();
        }

        private void DrawSymbolOnBoard(int choice)
        {
            if (_board.CurrentTurn == Piece.X)
                Cross.Draw(_canvases[choice]);
            else
                Circle.Draw(_canvases[choice]);
        }

        private void PerformAction(int choice)
        {
            if (_board.IsCellOccupied(choice))
                ShowError();
            else
            {
                _board.MakeMove(choice);
                DrawSymbolOnBoard(choice);
                if (_board.IsGameOver())
                    GameOver();
                else if (Difficulty.SelectedIndex != 3)
                {
                    MakeAiMove();
                    DrawSymbolOnBoard(_board.LatestTurnIndex);
                    if (_board.IsGameOver())
                        GameOver();
                }
            }
        }

        private void ResetGame()
        {
            foreach (var canvas in _canvases)
                canvas.Value.Children.Clear();
            _board = new Board();
        }

        private void Box0_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(0);
        }

        private void Box1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(1);
        }

        private void Box2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(2);
        }

        private void Box3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(3);
        }

        private void Box4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(4);
        }

        private void Box5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(5);
        }

        private void Box6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(6);
        }

        private void Box7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(7);
        }

        private void Box8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PerformAction(8);
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_start)
                _start = false;
            else
                ResetGame();
        }
    }
}