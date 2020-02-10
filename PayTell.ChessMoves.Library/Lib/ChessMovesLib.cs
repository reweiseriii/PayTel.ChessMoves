using System.Collections.Generic;
using PayTell.ChessMoves.Library.Entities;
using PayTell.ChessMoves.Library.Models;

namespace PayTell.ChessMoves.Library.Lib
{
    public class ChessMovesLib
    {
        private static readonly BoardLib BoardLib = new BoardLib();
        private ChessBoardEntity _board = new ChessBoardEntity();
        public ChessMovesLib()
        {
            _board = BoardLib.BuildBoard();
        }

        public ChessPiecesEntity GetChessPieceList()
        {
            return new ChessPiecesEntity();
        }

        public List<ChessCoordinatesEntity> GetValidMoves(string chessPiece, string startingCoordinate)
        {
            
            var chessCoordinates = new List<ChessCoordinatesEntity>
            {
                (new ChessCoordinatesEntity("a1")),
                (new ChessCoordinatesEntity("b2")),
                (new ChessCoordinatesEntity("c3")),
                (new ChessCoordinatesEntity("b4"))
            };

            return chessCoordinates;
        }

        public string GetChessMovesString(List<ChessCoordinatesEntity> coordinates)
        {
            string result = null;
            foreach (var coordinate in coordinates)
            {
                result = result + "," + coordinate.Coordinate;
            }

            result = result?.Substring(1, result.Length - 1);

            return result;
        }
    }
}
