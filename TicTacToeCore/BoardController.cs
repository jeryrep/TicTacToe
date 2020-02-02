using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToeCore.Difficulty;
using TicTacToeCore.Symbols;

namespace TicTacToeCore
{
    internal class BoardController
    {
        private char[] _cells;
        private readonly Dictionary<int, Canvas> _canvases;
        private readonly int _mode;
        private int _round = 0;
        private readonly Circle _circle = new Circle();
        private readonly Cross _cross = new Cross();
        private readonly EasyDifficulty _easyDifficulty = new EasyDifficulty();

        public void ClearBoard()
        {
            foreach (var canvas in _canvases)
                canvas.Value.Children.Clear();
            _cells = "         ".ToCharArray();
            _round = 0;
        }

        private void MakeComputerMove()
        {
            int computerMove;
            if (_mode == 0)
            {
                computerMove = _easyDifficulty.MakeMove(_cells);
                _cells[computerMove] = 'o';
                _circle.Draw(_canvases[computerMove]);
            }
            if (_mode == 1)
            {
                var mediumDifficulty = new MediumDifficulty(_cells);
                computerMove = mediumDifficulty.MakeMove();
                _cells[computerMove] = 'o';
                _circle.Draw(_canvases[computerMove]);
            }
        }

        private bool AnalyzeBoardState()
        {
            if ((_cells[0] == 'x' && _cells[1] == 'x' && _cells[2] == 'x') ||
                (_cells[3] == 'x' && _cells[4] == 'x' && _cells[5] == 'x') ||
                (_cells[6] == 'x' && _cells[7] == 'x' && _cells[8] == 'x') ||
                (_cells[0] == 'x' && _cells[3] == 'x' && _cells[6] == 'x') ||
                (_cells[1] == 'x' && _cells[4] == 'x' && _cells[7] == 'x') ||
                (_cells[2] == 'x' && _cells[5] == 'x' && _cells[8] == 'x') ||
                (_cells[0] == 'x' && _cells[4] == 'x' && _cells[8] == 'x') ||
                (_cells[2] == 'x' && _cells[4] == 'x' && _cells[6] == 'x'))
            {
                MessageBox.Show("X won!", "Game over!");
                ClearBoard();
                return true;
            }
            if ((_cells[0] == 'o' && _cells[1] == 'o' && _cells[2] == 'o') || 
                (_cells[3] == 'o' && _cells[4] == 'o' && _cells[5] == 'o') ||
                (_cells[6] == 'o' && _cells[7] == 'o' && _cells[8] == 'o') ||
                (_cells[0] == 'o' && _cells[3] == 'o' && _cells[6] == 'o') ||
                (_cells[1] == 'o' && _cells[4] == 'o' && _cells[7] == 'o') ||
                (_cells[2] == 'o' && _cells[5] == 'o' && _cells[8] == 'o') ||
                (_cells[0] == 'o' && _cells[4] == 'o' && _cells[8] == 'o') ||
                (_cells[2] == 'o' && _cells[4] == 'o' && _cells[6] == 'o'))
            {
                MessageBox.Show("O won!", "Game over!");
                ClearBoard();
                return true;
            }
            if (_round == 9)
            {
                MessageBox.Show("Draw!", "Game over");
                ClearBoard();
                return true;
            }
            return false;
        }

        public void ProcessClick(int index)
        {
            if (_cells[index] != ' ')
                MessageBox.Show("Select not occupied cell.", "Cell occupied");
            else
            {
                _round++;
                if (_mode == 3)
                {
                    if (_round % 2 != 0)
                    {
                        _cross.Draw(_canvases[index]);
                        _cells[index] = 'x';
                    }
                    else
                    {
                        _circle.Draw(_canvases[index]);
                        _cells[index] = 'o';
                    }
                    AnalyzeBoardState();
                }
                else if (_mode == 0)
                {
                    _cross.Draw(_canvases[index]);
                    _cells[index] = 'x';
                    if (AnalyzeBoardState())
                        return;
                    _round++;
                    MakeComputerMove();
                    AnalyzeBoardState();
                }
                else if (_mode == 1)
                {
                    _cross.Draw(_canvases[index]);
                    _cells[index] = 'x';
                    if (AnalyzeBoardState())
                        return;
                    _round++;
                    MakeComputerMove();
                    AnalyzeBoardState();
                }
            }
        }

        public BoardController(int mode, Dictionary<int,Canvas> canvases)
        {
            _mode = mode;
            _canvases = canvases;
            _cells = "         ".ToCharArray();
        }
    }
}