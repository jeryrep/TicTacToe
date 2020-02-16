using TicTacToeCore.TicTacToe.Difficulty;

namespace TicTacToeCore.TicTacToe
{
    internal class Board
    {
        private readonly Piece[] _board = { Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty };
        public Piece CurrentTurn { get; private set; }
        public int LatestTurnIndex { get; private set; }

        public bool IsCellOccupied(int choice) => _board[choice] != Piece.Empty;

        public bool IsGameOver() => BoardAnalyzer.CheckGameWin(_board, SwitchPiece()) || BoardAnalyzer.CheckGameEnd(_board);

        public Piece SwitchPiece() => CurrentTurn == Piece.X ? Piece.O : Piece.X;

        public void MakeMediumMove()
        {
            MakeMove(MediumDifficulty.GetIndex(_board));
        }

        public void MakeImpossibleMove()
        {
            MakeMove(ImpossibleDifficulty.GetIndex(_board));
        }

        public void MakeEasyMove()
        {
            MakeMove(EasyDifficulty.GetIndex(_board));
        }

        public void MakeMove(int choice)
        {
            _board[choice] = CurrentTurn;
            LatestTurnIndex = choice;
            CurrentTurn = SwitchPiece();
        }

        public Board()
        {
            CurrentTurn = Piece.X;
        }
    }
}