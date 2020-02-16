using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToeCore.Symbols;
using TicTacToeCore.TicTacToe;

namespace TicTacToeCore
{
    internal class GameController
    {
        private Board _board;
        private readonly Dictionary<int, Canvas> _canvases;
        private readonly int _difficulty;

        private void MakeAiMove()
        {
            switch (_difficulty)
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
                    MakeAiMove();
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
            _board = new Board();
        }

        public GameController(Dictionary<int, Canvas> canvases, int difficulty)
        {
            _canvases = canvases;
            _difficulty = difficulty;
            _board = new Board();
        }
    }
}