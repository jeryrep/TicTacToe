using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.WPF.Symbols;
using TicTacToe.Core.Game;

namespace TicTacToe.WPF
{
    internal class GameController
    {
        private Board _board;
        private readonly Dictionary<int, Canvas> _canvases;
        private readonly int _difficulty;

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
                Circle.Draw(_canvases[choice]);
            else
                Cross.Draw(_canvases[choice]);
        }

        public void PerformAction(int choice)
        {
            if (_board.IsCellOccupied(choice))
                ShowError();
            else
            {
                _board.MakeMove(choice);
                DrawSymbolOnBoard(choice);
                if (_board.IsGameOver())
                    GameOver();
                else if (_difficulty != 3)
                {
                    _board.MakeAiMove();
                    DrawSymbolOnBoard(_board.LatestTurnIndex);
                    if (_board.IsGameOver())
                        GameOver();
                }
            }
        }

        public void ResetGame()
        {
            foreach (var canvas in _canvases)
                canvas.Value.Children.Clear();
            _board = new Board(_difficulty);
        }

        public GameController(Dictionary<int, Canvas> canvases, int difficulty)
        {
            _canvases = canvases;
            _difficulty = difficulty;
            _board = new Board(difficulty);
        }
    }
}