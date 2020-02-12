using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToeCore.Difficulty;
using TicTacToeCore.Symbols;

namespace TicTacToeCore
{
    internal class BoardController
    {
        private Piece[] _cells;
        private readonly Dictionary<int, Canvas> _canvases;
        private readonly int _mode;
        private int _round = 0;

        public void ResetGame()
        {
            foreach (var canvas in _canvases)
                canvas.Value.Children.Clear();
            _cells = new Piece[9];
            _round = 0;
        }

        private void MakeComputerMove()
        {
            int computerMove;
            switch (_mode)
            {
                case 0:
                    computerMove = EasyDifficulty.GetIndex(_cells);
                    _cells[computerMove] = Piece.O;
                    Circle.Draw(_canvases[computerMove]);
                    break;
                case 1:
                    computerMove = MediumDifficulty.GetIndex(_cells);
                    _cells[computerMove] = Piece.O;
                    Circle.Draw(_canvases[computerMove]);
                    break;
            }
        }

        public void ProcessClick(int index)
        {
            if (_cells[index] != Piece.Empty)
                MessageBox.Show("Select not occupied cell.", "Cell occupied");
            else
            {
                _round++;
                switch (_mode)
                {
                    case 3:
                    {
                        if (_round % 2 != 0)
                        {
                            Cross.Draw(_canvases[index]);
                            _cells[index] = Piece.X;
                            BoardAnalyzer.CheckGameWin(_cells, Piece.X);
                        }
                        else
                        {
                            Circle.Draw(_canvases[index]);
                            _cells[index] = Piece.X;
                            BoardAnalyzer.CheckGameWin(_cells, Piece.O);
                        }
                        break;
                    }
                    case 0:
                    {
                        Cross.Draw(_canvases[index]);
                        _cells[index] = Piece.X;
                        if (BoardAnalyzer.CheckGameWin(_cells, Piece.X))
                        {
                            MessageBox.Show("X won!", "Game over");
                            ResetGame();
                            return;
                        }
                        _round++;
                        MakeComputerMove();
                        BoardAnalyzer.CheckGameWin(_cells, Piece.O);
                        break;
                    }
                    case 1:
                    {
                        Cross.Draw(_canvases[index]);
                        _cells[index] = Piece.X;
                        if (BoardAnalyzer.CheckGameWin(_cells, Piece.X))
                            return;
                        _round++;
                        MakeComputerMove();
                        BoardAnalyzer.CheckGameWin(_cells, Piece.O);
                        break;
                    }
                }
            }
        }

        public BoardController(int mode, Dictionary<int,Canvas> canvases)
        {
            _mode = mode;
            _canvases = canvases;
            _cells = new Piece[9];
        }
    }
}