using System.Collections.Generic;
using System.Linq;

namespace TicTacToeCore.TicTacToe.Difficulty
{
    internal class ImpossibleCpuPlayer : IDifficultyCpuPlayer
    {
        private const Piece Computer = Piece.O;
        private const Piece Player = Piece.X;
        private static int _choice;

        private static int Minimax(IReadOnlyList<Piece> inputBoard, Piece player)
        {
            var board = CloneBoard(inputBoard);

            if (CheckScore(board) != 0)
                return CheckScore(board);
            if (BoardAnalyzer.CheckGameEnd(board))
                return 0;

            var scores = new List<int>();
            var moves = new List<int>();

            for (var i = 0; i < 9; i++)
            {
                if (board[i] != Piece.Empty)
                    continue;
                scores.Add(Minimax(MakeBoardMove(board, player, i), SwitchPiece(player)));
                moves.Add(i);
            }
            if (player == Computer)
            {
                _choice = moves[scores.IndexOf(scores.Max())];
                return scores.Max();
            }
            _choice = moves[scores.IndexOf(scores.Min())];
            return scores.Min();
        }

        private static int CheckScore(Piece[] board)
        {
            if (BoardAnalyzer.CheckGameWin(board, Computer))
                return 10;
            if (BoardAnalyzer.CheckGameWin(board, Player))
                return -10;
            return 0;
        }

        private static Piece SwitchPiece(Piece piece) => piece == Piece.X ? Piece.O : Piece.X;

        private static Piece[] CloneBoard(IReadOnlyList<Piece> board)
        {
            var clone = new Piece[9];
            for (var i = 0; i < 9; i++)
                clone[i] = board[i];
            return clone;
        }

        private static Piece[] MakeBoardMove(IReadOnlyList<Piece> board, Piece move, int position)
        {
            var newBoard = CloneBoard(board);
            newBoard[position] = move;
            return newBoard;
        }

        public int GetNextMove(Piece[] board)
        {
            Minimax(board, Computer);
            return _choice;
        }
    }
}