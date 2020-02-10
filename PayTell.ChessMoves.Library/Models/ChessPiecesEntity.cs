using System.Collections.Generic;
using PayTell.ChessMoves.Library.Entities;

namespace PayTell.ChessMoves.Library.Models
{
    public class ChessPiecesEntity
    {
        public string PieceName { get; set; }
        public int MaxMoves { get; set; }
        public List<DirectionTypeEntity> DirectionTypeList { get; set; }

        public List<GridCoordinateEntity> GridCoordinateList { get; set; }
    }
}
