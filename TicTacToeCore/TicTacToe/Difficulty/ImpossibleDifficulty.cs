using System.Collections.Generic;
using System.Linq;

namespace TicTacToeCore.TicTacToe.Difficulty
{
    internal class ImpossibleDifficulty
    {
        private const Piece Computer = Piece.O;
        private const Piece Player = Piece.X;

        private static int Minimax(IReadOnlyList<Piece> inputBoard, Piece player)
        {
            var board = CloneBoard(inputBoard);

            if (CheckScore(board) != 0)
                return CheckScore(board);
            if (BoardAnalyzer.CheckGameEnd(board))
                return 0;

            var moveScore = new Dictionary<int, int>();

            for (var i = 0; i < 9; i++)
            {
                if (board[i] != Piece.Empty)
                    continue;
                var score = Minimax(MakeBoardMove(board, player, i), SwitchPiece(player));
                moveScore.Add(i, score);
            }
            return moveScore.Aggregate((key, score) => key.Value > score.Value ? key : score).Key;
            /*if (player == Computer)
            {
                var maxScoreIndex = moveScore.Aggregate((key, score) => key.Value > score.Value ? key : score).Key;
                return maxScoreIndex;
            }
            var minScoreIndex = moveScore.Aggregate((key, score) => key.Value < score.Value ? key : score).Key;
            return minScoreIndex;*/
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

        public static int GetIndex(Piece[] board) => Minimax(board, Computer);
    }
}