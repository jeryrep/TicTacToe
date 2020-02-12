using System;
using System.Collections.Generic;

namespace TicTacToeCore.Difficulty
{
    internal class MediumDifficulty
    {
        private static int CheckLosingPosition(IReadOnlyList<Piece> board)
        {
            if ((board[0] == Piece.Empty && board[1] == Piece.X && board[2] == Piece.X) ||
                (board[0] == Piece.Empty && board[3] == Piece.X && board[6] == Piece.X) ||
                (board[0] == Piece.Empty && board[4] == Piece.X && board[8] == Piece.X))
                return 0;
            if ((board[0] == Piece.X && board[1] == Piece.Empty && board[2] == Piece.X) ||
                (board[1] == Piece.Empty && board[4] == Piece.X && board[7] == Piece.X))
                return 1;
            if ((board[0] == Piece.X && board[1] == Piece.X && board[2] == Piece.Empty) || 
                (board[2] == Piece.Empty && board[5] == Piece.X && board[8] == Piece.X) ||
                (board[2] == Piece.Empty && board[4] == Piece.X && board[6] == Piece.X))
                return 2;
            if ((board[3] == Piece.Empty && board[4] == Piece.X && board[5] == Piece.X) ||
                (board[0] == Piece.X && board[3] == Piece.Empty && board[6] == Piece.X))
                return 3;
            if ((board[3] == Piece.X && board[4] == Piece.Empty && board[5] == Piece.X) ||
                (board[1] == Piece.X && board[4] == Piece.Empty && board[7] == Piece.X) ||
                (board[0] == Piece.X && board[4] == Piece.Empty && board[8] == Piece.X) ||
                (board[2] == Piece.X && board[4] == Piece.Empty && board[6] == Piece.X))
                return 4;
            if ((board[3] == Piece.X && board[4] == Piece.X && board[5] == Piece.Empty) ||
                (board[2] == Piece.X && board[5] == Piece.Empty && board[8] == Piece.X))
                return 5;
            if ((board[6] == Piece.Empty && board[7] == Piece.X && board[8] == Piece.X) ||
                (board[2] == Piece.X && board[4] == Piece.X && board[6] == Piece.Empty) ||
                (board[0] == Piece.X && board[3] == Piece.X && board[6] == Piece.Empty))
                return 6;
            if ((board[6] == Piece.X && board[7] == Piece.Empty && board[8] == Piece.X) ||
                (board[1] == Piece.X && board[4] == Piece.X && board[7] == Piece.Empty))
                return 7;
            if ((board[6] == Piece.X && board[7] == Piece.X && board[8] == Piece.Empty) ||
                (board[2] == Piece.X && board[5] == Piece.X && board[8] == Piece.Empty) ||
                (board[0] == Piece.X && board[4] == Piece.X && board[8] == Piece.Empty))
                return 8;
            return -1;
        }

        private static int CheckWinningPosition(IReadOnlyList<Piece> board)
        {
            if ((board[0] == Piece.Empty && board[1] == Piece.O && board[2] == Piece.O) ||
                (board[0] == Piece.Empty && board[3] == Piece.O && board[6] == Piece.O) ||
                (board[0] == Piece.Empty && board[4] == Piece.O && board[8] == Piece.O))
                return 0;
            if ((board[0] == Piece.O && board[1] == Piece.Empty && board[2] == Piece.O) ||
                (board[1] == Piece.Empty && board[4] == Piece.O && board[7] == Piece.O))
                return 1;
            if ((board[0] == Piece.O && board[1] == Piece.O && board[2] == Piece.Empty) ||
                (board[2] == Piece.Empty && board[5] == Piece.O && board[8] == Piece.O) ||
                (board[2] == Piece.Empty && board[4] == Piece.O && board[6] == Piece.O))
                return 2;
            if ((board[3] == Piece.Empty && board[4] == Piece.O && board[5] == Piece.O) ||
                (board[0] == Piece.O && board[3] == Piece.Empty && board[6] == Piece.O))
                return 3;
            if ((board[3] == Piece.O && board[4] == Piece.Empty && board[5] == Piece.O) ||
                (board[1] == Piece.O && board[4] == Piece.Empty && board[7] == Piece.O) ||
                (board[0] == Piece.O && board[4] == Piece.Empty && board[8] == Piece.O) ||
                (board[2] == Piece.O && board[4] == Piece.Empty && board[6] == Piece.O))
                return 4;
            if ((board[3] == Piece.O && board[4] == Piece.O && board[5] == Piece.Empty) ||
                (board[2] == Piece.O && board[5] == Piece.Empty && board[8] == Piece.O))
                return 5;
            if ((board[6] == Piece.Empty && board[7] == Piece.O && board[8] == Piece.O) ||
                (board[2] == Piece.O && board[4] == Piece.O && board[6] == Piece.Empty) ||
                (board[0] == Piece.O && board[3] == Piece.O && board[6] == Piece.Empty))
                return 6;
            if ((board[6] == Piece.O && board[7] == Piece.Empty && board[8] == Piece.O) ||
                (board[1] == Piece.O && board[4] == Piece.O && board[7] == Piece.Empty))
                return 7;
            if ((board[6] == Piece.O && board[7] == Piece.O && board[8] == Piece.Empty) ||
                (board[2] == Piece.O && board[5] == Piece.O && board[8] == Piece.Empty) ||
                (board[0] == Piece.O && board[4] == Piece.O && board[8] == Piece.Empty))
                return 8;
            return -1;
        }

        private static int SuggestedCell(IReadOnlyList<Piece> board)
        {
            var winningCell = CheckWinningPosition(board);
            if (winningCell != -1)
                return winningCell;
            var losingCell = CheckLosingPosition(board);
            if (losingCell != -1)
                return losingCell;
            return -1;
        }

        private static int GenerateRandomNumber() => new Random().Next(0, 9);

        public static int GetIndex(Piece[] board)
        {
            var suggestedCell = SuggestedCell(board);
            if (suggestedCell != -1)
                return suggestedCell;
            int randomCell;
            do
                randomCell = GenerateRandomNumber();
            while (board[randomCell] != Piece.Empty);
            return randomCell;
        }
    }
}