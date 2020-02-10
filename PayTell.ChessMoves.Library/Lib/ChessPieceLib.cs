using System.Collections.Generic;
using PayTell.ChessMoves.Library.Entities;
using PayTell.ChessMoves.Library.Enums;
using PayTell.ChessMoves.Library.Models;

namespace PayTell.ChessMoves.Library.Lib
{
    public class ChessPieceLib
    {
        public List<ChessPiecesEntity> GetPieces()
        {
            var chestPieces = new List<ChessPiecesEntity>
            {
                GetKing(), 
                GetQueen(), 
                GetRook(), 
                GetBishop()
            };

            return chestPieces;
        }

        private ChessPiecesEntity GetBishop()
        {
            var directionTypeList = new List<DirectionTypeEntity>
            {
                new DirectionTypeEntity {Direction = DirectionsEnum.Diagonal.ToString()}
            };

            var chessPiece = new ChessPiecesEntity
            {
                PieceName = ChessPieceNamesEnum.Bishop.ToString(), 
                MaxMoves = 7,
                DirectionTypeList = directionTypeList // Add the last property here
            };

            // Create a method in this class to generate a list of coordinates that can be added
            // to the gridcoordinatelist property

            return chessPiece;
        }

        private ChessPiecesEntity GetRook()
        {
            var directionTypeList = new List<DirectionTypeEntity>
            {
                new DirectionTypeEntity {Direction = DirectionsEnum.Horizontal.ToString()},
                new DirectionTypeEntity {Direction = DirectionsEnum.Vertical.ToString()}
            };

            var chessPiece = new ChessPiecesEntity
            {
                PieceName = ChessPieceNamesEnum.Rook.ToString(),
                MaxMoves = 7,
                DirectionTypeList = directionTypeList
            };

            return chessPiece;
        }

        private ChessPiecesEntity GetQueen()
        {
            var directionTypeList = new List<DirectionTypeEntity>
            {
                new DirectionTypeEntity {Direction = DirectionsEnum.Horizontal.ToString()},
                new DirectionTypeEntity {Direction = DirectionsEnum.Vertical.ToString()},
                new DirectionTypeEntity {Direction = DirectionsEnum.Diagonal.ToString()}
            };

            var chessPiece = new ChessPiecesEntity
            {
                PieceName = ChessPieceNamesEnum.Queen.ToString(),
                MaxMoves = 7,
                DirectionTypeList = directionTypeList
            };

            return chessPiece;
        }

        private ChessPiecesEntity GetKing()
        {
            var directionTypeList = new List<DirectionTypeEntity>
            {
                new DirectionTypeEntity {Direction = DirectionsEnum.Horizontal.ToString()},
                new DirectionTypeEntity {Direction = DirectionsEnum.Vertical.ToString()},
                new DirectionTypeEntity {Direction = DirectionsEnum.Diagonal.ToString()}
            };

            var chessPiece = new ChessPiecesEntity
            {
                PieceName = ChessPieceNamesEnum.King.ToString(),
                MaxMoves = 1,
                DirectionTypeList = directionTypeList
            };

            return chessPiece;
        }
    }
}
