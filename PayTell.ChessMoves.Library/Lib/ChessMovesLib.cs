using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using PayTel.ChessMoves.Library.Entities;
using PayTel.ChessMoves.Library.Models;

namespace PayTel.ChessMoves.Library.Lib
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

        public List<ChessCoordinatesEntity> GetValidMoves(string chessPiece, string startingChessCoordinate)
        {
            var startGridCoordinate = GetGridCoordinateFromChessCoordinate(startingChessCoordinate);

            var validGridMoveCoordinatesList = GetValidGridMoveCoordinatesList(chessPiece,startGridCoordinate);

            return validGridMoveCoordinatesList;
        }

        private List<ChessCoordinatesEntity> GetValidGridMoveCoordinatesList(string chessPiece, 
            GridCoordinateEntity startGridCoordinate)
        {
            var gridCoordinateEntityList = 
                GetGridCoordinatesFromInstructions(GetChessPieceEntityByName(chessPiece), startGridCoordinate);

            var validCoordinateEntityList = GetChessCoordinateListFromGridList(gridCoordinateEntityList);

            return validCoordinateEntityList;
        }

        private List<ChessCoordinatesEntity> GetChessCoordinateListFromGridList(IEnumerable<GridCoordinateEntity> gridCoordinateEntityList)
        {
            var chessCoordinatesEntityList =  gridCoordinateEntityList
                .Select(GetChessCoordinateFromGridCoordinate)
                .OrderBy(a=>a.Coordinate)
                .ToList();

            return chessCoordinatesEntityList;
        }

        private IEnumerable<GridCoordinateEntity> GetGridCoordinatesFromInstructions(ChessPiecesEntity chessPiecesEntity,
            GridCoordinateEntity startGridCoordinate)
        {
            var gridCoordinateEntityList = new List<GridCoordinateEntity>();

            foreach (var gridCoordinateEntity in chessPiecesEntity.GridCoordinateInstructionList)
            {
                var validGridCoordinateEntity = new GridCoordinateEntity
                {
                    XCoordinate = gridCoordinateEntity.XCoordinate + startGridCoordinate.XCoordinate,
                    YCoordinate = gridCoordinateEntity.YCoordinate + startGridCoordinate.YCoordinate
                };

                if (IsValid(validGridCoordinateEntity))
                {
                    gridCoordinateEntityList.Add(validGridCoordinateEntity);
                }
            }

            return gridCoordinateEntityList;
        }

        private bool IsValid(GridCoordinateEntity validGridCoordinateEntity)
        {
            var isValid = 
                !(validGridCoordinateEntity.XCoordinate > 7) && 
                !(validGridCoordinateEntity.XCoordinate < 0) && 
                !(validGridCoordinateEntity.YCoordinate > 7) && 
                !(validGridCoordinateEntity.YCoordinate < 0);

            return isValid;
        }

        private ChessPiecesEntity GetChessPieceEntityByName(string chessPiece)
        {
            var chessPieceEntity = new ChessPiecesEntity();

            foreach (var item in _board.ChessPieceList.Where(item => chessPiece == item.PieceName))
            {
                chessPieceEntity = item;
                break;
            }

            return chessPieceEntity;
        }


        private ChessCoordinatesEntity GetChessCoordinateFromGridCoordinate(GridCoordinateEntity gridCoordinate)
        {
            var x = gridCoordinate.XCoordinate;
            var y = gridCoordinate.YCoordinate;

            var chessY = (y + 1).ToString();
            var chessX = (char)(x + 97);

            var chessCoordinate = new ChessCoordinatesEntity($"{chessX}{chessY}");

            return chessCoordinate;
        }

        private GridCoordinateEntity GetGridCoordinateFromChessCoordinate(string startingChessCoordinate)
        {
            //Note, we are not checking the coordinate to validate that it's incorrect. We can add handling in this later.
            var chessX = startingChessCoordinate.Substring(0, 1);
            var chessY = startingChessCoordinate.Substring(1, 1);

            var x = Convert.ToInt16(chessY) - 1;
            var y = Convert.ToChar(chessX.ToLower()) - 97;

            var coordinate = new GridCoordinateEntity {YCoordinate = x, XCoordinate = y};

            return coordinate;
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
