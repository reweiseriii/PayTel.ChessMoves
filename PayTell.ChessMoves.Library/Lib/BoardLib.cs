using PayTell.ChessMoves.Library.Models;

namespace PayTell.ChessMoves.Library.Lib
{
    public class BoardLib
    {
        private readonly ChessPieceLib _chessPieceLibrary = new ChessPieceLib();

        public ChessBoardEntity BuildBoard()
        {
            var chessBoardEntity = new ChessBoardEntity();
            var chessPieceList = _chessPieceLibrary.GetPieces();
            chessBoardEntity.ChessPieceList = chessPieceList;

            return chessBoardEntity;
        }
    
    }
}
