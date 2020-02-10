using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PayTel.ChessMoves.Library.Entities;
using PayTel.ChessMoves.Library.Enums;
using PayTel.ChessMoves.Library.Models;

namespace PayTel.ChessMoves.Library.Lib
{
    public class ChessPieceLib
    {
        public List<ChessPiecesEntity> GetPieces()
        {
            var chestPieces = new List<ChessPiecesEntity>
            {
                GetBishop(),
                GetKing(),
                GetQueen(),
                GetRook()
                
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
                DirectionTypeList = directionTypeList,
                GridCoordinateInstructionList = null
            };

            List<GridCoordinateEntity> gridCoordinateInstructionList = GetGridCoordinateInstructionList(chessPiece);
            chessPiece.GridCoordinateInstructionList = gridCoordinateInstructionList;
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

            List<GridCoordinateEntity> gridCoordinateInstructionList = GetGridCoordinateInstructionList(chessPiece);
            chessPiece.GridCoordinateInstructionList = gridCoordinateInstructionList;

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

            List<GridCoordinateEntity> gridCoordinateInstructionList = GetGridCoordinateInstructionList(chessPiece);
            chessPiece.GridCoordinateInstructionList = gridCoordinateInstructionList;

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
                DirectionTypeList = directionTypeList,
                GridCoordinateInstructionList = null
            };

            List<GridCoordinateEntity> gridCoordinateInstructionList = GetGridCoordinateInstructionList(chessPiece);
            chessPiece.GridCoordinateInstructionList = gridCoordinateInstructionList;

            return chessPiece;
        }

        private List<GridCoordinateEntity> GetGridCoordinateInstructionList(ChessPiecesEntity chessPiece)
        {
            List<GridCoordinateEntity> coordinateList = new List<GridCoordinateEntity>();

            foreach (var directionType in chessPiece.DirectionTypeList)
            {
                if (directionType.Direction == DirectionsEnum.Horizontal.ToString())
                {
                    coordinateList = GetCoordinateInstructionListForHorizontal(chessPiece,coordinateList);
                }

                if (directionType.Direction == DirectionsEnum.Vertical.ToString())
                {
                    coordinateList = GetCoordinateInstructionListForVertical(chessPiece,coordinateList);

                }

                if (directionType.Direction == DirectionsEnum.Diagonal.ToString())
                {
                    coordinateList = GetCoordinateInstructionListForDiagonal(chessPiece, coordinateList);

                }
            }

            return coordinateList;
        }

        private List<GridCoordinateEntity> GetCoordinateInstructionListForDiagonal(ChessPiecesEntity chessPiece, 
            List<GridCoordinateEntity> coordinateList)
        {
            //For Diagonal
            var x = -(chessPiece.MaxMoves);
            var y = (chessPiece.MaxMoves);

            for (var i = -(chessPiece.MaxMoves); i <= chessPiece.MaxMoves; i++)
            {
                if (!(x == 0 && y == 0))
                {
                    coordinateList.Add(new GridCoordinateEntity {XCoordinate = x, YCoordinate = y});
                }

                x++;
                y--;
            }

            x = -(chessPiece.MaxMoves);
            y = -(chessPiece.MaxMoves);

            for (var i = -(chessPiece.MaxMoves); i <= chessPiece.MaxMoves; i++)
            {
                if (!(x == 0 && y == 0))
                {
                    coordinateList.Add(new GridCoordinateEntity {XCoordinate = x, YCoordinate = y});
                }

                x++;
                y++;
            }

            return coordinateList;
        }

        private List<GridCoordinateEntity> GetCoordinateInstructionListForVertical(ChessPiecesEntity chessPiece,
            List<GridCoordinateEntity> coordinateList)
        {
            //For Vertical
            var x = 0;
            var y = -(chessPiece.MaxMoves);

            for (var i = -(chessPiece.MaxMoves); i <= chessPiece.MaxMoves; i++)
            {
                if (!(x == 0 && y == 0))
                {
                    coordinateList.Add(new GridCoordinateEntity {XCoordinate = x, YCoordinate = y});
                }

                y++;
            }

            return coordinateList;

        }

        private List<GridCoordinateEntity> GetCoordinateInstructionListForHorizontal(ChessPiecesEntity chessPiece,
            List<GridCoordinateEntity> coordinateList)
        {
            //For Horizontal
            var x = -(chessPiece.MaxMoves);
            var y = 0;

            for (var i = -(chessPiece.MaxMoves); i <= chessPiece.MaxMoves; i++)
            {
                if (!(x == 0 && y==0))
                {
                    coordinateList.Add(new GridCoordinateEntity {XCoordinate = x, YCoordinate = y});
                }
                x++;
            }

            return coordinateList;
        }
    }


}
