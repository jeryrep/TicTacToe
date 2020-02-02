using System;
using System.Windows;

namespace TicTacToeCore.Difficulty
{
    internal class MediumDifficulty
    {
        private readonly char[] _board;
        private readonly Random _random = new Random();

        private int CheckLosingPosition()
        {
            if ((_board[0] == ' ' && _board[1] == 'x' && _board[2] == 'x') ||
                (_board[0] == ' ' && _board[3] == 'x' && _board[6] == 'x') ||
                (_board[0] == ' ' && _board[4] == 'x' && _board[8] == 'x'))
                return 0;
            if ((_board[0] == 'x' && _board[1] == ' ' && _board[2] == 'x') ||
                (_board[1] == ' ' && _board[4] == 'x' && _board[7] == 'x'))
                return 1;
            if ((_board[0] == 'x' && _board[1] == 'x' && _board[2] == ' ') || 
                (_board[2] == ' ' && _board[5] == 'x' && _board[8] == 'x') ||
                (_board[2] == ' ' && _board[4] == 'x' && _board[6] == 'x'))
                return 2;
            if ((_board[3] == ' ' && _board[4] == 'x' && _board[5] == 'x') ||
                (_board[0] == 'x' && _board[3] == ' ' && _board[6] == 'x'))
                return 3;
            if ((_board[3] == 'x' && _board[4] == ' ' && _board[5] == 'x') ||
                (_board[1] == 'x' && _board[4] == ' ' && _board[7] == 'x') ||
                (_board[0] == 'x' && _board[4] == ' ' && _board[8] == 'x') ||
                (_board[2] == 'x' && _board[4] == ' ' && _board[6] == 'x'))
                return 4;
            if ((_board[3] == 'x' && _board[4] == 'x' && _board[5] == ' ') ||
                (_board[2] == 'x' && _board[5] == ' ' && _board[8] == 'x'))
                return 5;
            if ((_board[6] == ' ' && _board[7] == 'x' && _board[8] == 'x') ||
                (_board[2] == 'x' && _board[4] == 'x' && _board[6] == ' ') ||
                (_board[0] == 'x' && _board[3] == 'x' && _board[6] == ' '))
                return 6;
            if ((_board[6] == 'x' && _board[7] == ' ' && _board[8] == 'x') ||
                (_board[1] == 'x' && _board[4] == 'x' && _board[7] == ' '))
                return 7;
            if ((_board[6] == 'x' && _board[7] == 'x' && _board[8] == ' ') ||
                (_board[2] == 'x' && _board[5] == 'x' && _board[8] == ' ') ||
                (_board[0] == 'x' && _board[4] == 'x' && _board[8] == ' '))
                return 8;
            return -1;
        }

        private int CheckWinningPosition()
        {
            if ((_board[0] == ' ' && _board[1] == 'o' && _board[2] == 'o') ||
                (_board[0] == ' ' && _board[3] == 'o' && _board[6] == 'o') ||
                (_board[0] == ' ' && _board[4] == 'o' && _board[8] == 'o'))
                return 0;
            if ((_board[0] == 'o' && _board[1] == ' ' && _board[2] == 'o') ||
                (_board[1] == ' ' && _board[4] == 'o' && _board[7] == 'o'))
                return 1;
            if ((_board[0] == 'o' && _board[1] == 'o' && _board[2] == ' ') ||
                (_board[2] == ' ' && _board[5] == 'o' && _board[8] == 'o') ||
                (_board[2] == ' ' && _board[4] == 'o' && _board[6] == 'o'))
                return 2;
            if ((_board[3] == ' ' && _board[4] == 'o' && _board[5] == 'o') ||
                (_board[0] == 'o' && _board[3] == ' ' && _board[6] == 'o'))
                return 3;
            if ((_board[3] == 'o' && _board[4] == ' ' && _board[5] == 'o') ||
                (_board[1] == 'o' && _board[4] == ' ' && _board[7] == 'o') ||
                (_board[0] == 'o' && _board[4] == ' ' && _board[8] == 'o') ||
                (_board[2] == 'o' && _board[4] == ' ' && _board[6] == 'o'))
                return 4;
            if ((_board[3] == 'o' && _board[4] == 'o' && _board[5] == ' ') ||
                (_board[2] == 'o' && _board[5] == ' ' && _board[8] == 'o'))
                return 5;
            if ((_board[6] == ' ' && _board[7] == 'o' && _board[8] == 'o') ||
                (_board[2] == 'o' && _board[4] == 'o' && _board[6] == ' ') ||
                (_board[0] == 'o' && _board[3] == 'o' && _board[6] == ' '))
                return 6;
            if ((_board[6] == 'o' && _board[7] == ' ' && _board[8] == 'o') ||
                (_board[1] == 'o' && _board[4] == 'o' && _board[7] == ' '))
                return 7;
            if ((_board[6] == 'o' && _board[7] == 'o' && _board[8] == ' ') ||
                (_board[2] == 'o' && _board[5] == 'o' && _board[8] == ' ') ||
                (_board[0] == 'o' && _board[4] == 'o' && _board[8] == ' '))
                return 8;
            return -1;
        }

        private int SuggestedCell()
        {
            int winningCell = CheckWinningPosition();
            if (winningCell != -1)
                return winningCell;
            int losingCell = CheckLosingPosition();
            if (losingCell != -1)
                return losingCell;
            return -1;
        }

        private int GenerateRandomNumber() => _random.Next(0, 9);

        public int MakeMove()
        {
            int suggestedCell = SuggestedCell();
            if (suggestedCell != -1)
                return suggestedCell;
            int randomCell;
            do
                randomCell = GenerateRandomNumber();
            while (!char.IsWhiteSpace(_board[randomCell]));
            return randomCell;
        }

        public MediumDifficulty(char[] board)
        {
            _board = board;
        }
    }
}