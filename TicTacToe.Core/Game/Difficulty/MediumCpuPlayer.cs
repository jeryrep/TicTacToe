using System.Collections.Generic;

namespace TicTacToe.Core.Game.Difficulty
{
    internal class MediumCpuPlayer : IDifficultyCpuPlayer
    {
        private static int CheckWinningOrLosingPosition(IReadOnlyList<Piece> board, Piece player)
        {
            if ((board[0] == Piece.Empty && board[1] == player && board[2] == player) ||
                (board[0] == Piece.Empty && board[3] == player && board[6] == player) ||
                (board[0] == Piece.Empty && board[4] == player && board[8] == player))
                return 0;
            if ((board[0] == player && board[1] == Piece.Empty && board[2] == player) ||
                (board[1] == Piece.Empty && board[4] == player && board[7] == player))
                return 1;
            if ((board[0] == player && board[1] == player && board[2] == Piece.Empty) ||
                (board[2] == Piece.Empty && board[5] == player && board[8] == player) ||
                (board[2] == Piece.Empty && board[4] == player && board[6] == player))
                return 2;
            if ((board[3] == Piece.Empty && board[4] == player && board[5] == player) ||
                (board[0] == player && board[3] == Piece.Empty && board[6] == player))
                return 3;
            if ((board[3] == player && board[4] == Piece.Empty && board[5] == player) ||
                (board[1] == player && board[4] == Piece.Empty && board[7] == player) ||
                (board[0] == player && board[4] == Piece.Empty && board[8] == player) ||
                (board[2] == player && board[4] == Piece.Empty && board[6] == player))
                return 4;
            if ((board[3] == player && board[4] == player && board[5] == Piece.Empty) ||
                (board[2] == player && board[5] == Piece.Empty && board[8] == player))
                return 5;
            if ((board[6] == Piece.Empty && board[7] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == Piece.Empty) ||
                (board[0] == player && board[3] == player && board[6] == Piece.Empty))
                return 6;
            if ((board[6] == player && board[7] == Piece.Empty && board[8] == player) ||
                (board[1] == player && board[4] == player && board[7] == Piece.Empty))
                return 7;
            if ((board[6] == player && board[7] == player && board[8] == Piece.Empty) ||
                (board[2] == player && board[5] == player && board[8] == Piece.Empty) ||
                (board[0] == player && board[4] == player && board[8] == Piece.Empty))
                return 8;
            return -1;
        }

        private static int SuggestedCell(IReadOnlyList<Piece> board)
        {
            var nextCell = CheckWinningOrLosingPosition(board, Piece.O);
            if (nextCell != -1)
                return nextCell;
            nextCell = CheckWinningOrLosingPosition(board, Piece.X);
            return nextCell != -1 ? nextCell : -1;
        }

        public int GetNextMove(Piece[] board)
        {
            var nextMove = SuggestedCell(board);
            return nextMove != -1 ? nextMove : new EasyCpuPlayer().GetNextMove(board);
        }
    }
}
