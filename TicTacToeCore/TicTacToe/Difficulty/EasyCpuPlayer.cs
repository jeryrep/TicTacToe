using System;

namespace TicTacToeCore.TicTacToe.Difficulty
{
    internal class EasyCpuPlayer : IDifficultyCpuPlayer
    {
        public int GetNextMove(Piece[] board)
        {
            var randomNumberGenerator = new Random();
            int randomCell;
            do
                randomCell = randomNumberGenerator.Next(0, 9);
            while (board[randomCell] != Piece.Empty);

            return randomCell;
        }
    }
}