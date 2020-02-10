using System.Collections.Generic;
using PayTel.ChessMoves.Library.Entities;

namespace PayTel.ChessMoves.Library.Models
{
    public class ChessPiecesEntity
    {
        public string PieceName { get; set; }
        public int MaxMoves { get; set; }
        public List<DirectionTypeEntity> DirectionTypeList { get; set; }
        public List<GridCoordinateEntity> GridCoordinateInstructionList { get; set; }
    }
}
