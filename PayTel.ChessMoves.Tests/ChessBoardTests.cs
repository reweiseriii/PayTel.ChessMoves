using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PayTel.ChessMoves.Library;
using PayTel.ChessMoves.Library.Entities;
using PayTel.ChessMoves.Library.Models;
using PayTel.ChessMoves.Library.Lib;

namespace PayTel.ChessMoves.Tests
{
    public class ChessBoardTests
    {
        [Fact]
        public void CanSetPieceName()
        {
            var chessPieceEntity = new ChessPiecesEntity();
            chessPieceEntity.PieceName = "King";
            chessPieceEntity.MaxMoves = 99;
            var chessPieceName = chessPieceEntity.PieceName;
            var chessPieceMaxMoves = chessPieceEntity.MaxMoves;
            Assert.Equal("King", chessPieceName);
            Assert.Equal(99, chessPieceMaxMoves);
        }

        private static ChessMovesLib Moves { get; } = new Library.Lib.ChessMovesLib();

        [Fact]
        public void GetBishopLegalMoves()
        {
            var validMoves = Moves.GetValidMoves("Bishop", "c3");
            var chessMovesString = Moves.GetChessMovesString(validMoves);
            Assert.Equal("a1,a5,b2,b4,d2,d4,e1,e5,f6,g7,h8", chessMovesString);
        }

        [Fact]
        public void GetKingLegalMoves()
        {
            var validMoves = Moves.GetValidMoves("King", "a1");
            var chessMovesString = Moves.GetChessMovesString(validMoves);
            Assert.Equal("a2,b1,b2", chessMovesString);
        }

        [Fact]
        public void GetRookLegalMoves()
        {
            var validMoves = Moves.GetValidMoves("Rook", "h2");
            var chessMovesString = Moves.GetChessMovesString(validMoves);
            Assert.Equal("a2,b2,c2,d2,e2,f2,g2,h1,h3,h4,h5,h6,h7,h8", chessMovesString);
        }
    }
}
