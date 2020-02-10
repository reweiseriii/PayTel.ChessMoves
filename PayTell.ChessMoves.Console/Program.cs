using PayTel.ChessMoves.Library.Lib;

namespace PayTel.ChessMoves.Console
{
    internal class Program
    {
        private static readonly Library.Lib.ChessMovesLib ChessMoves = new Library.Lib.ChessMovesLib();
        

        private static void Main()
        {
            while (1 == 1)
            {
                DoUserAction();
            }
        }


        private static void DoUserAction()
        {

            System.Console.WriteLine("Please enter your selected piece [King, Queen, Rook, Bishop] and press enter: ");
            var chessPiece = System.Console.ReadLine();
            System.Console.WriteLine("Using standard chess notation, enter your starting point: ");
            var startingCoordinate = System.Console.ReadLine();

            var validMoves = ChessMoves.GetValidMoves(chessPiece, startingCoordinate);
            System.Console.WriteLine(chessPiece + " - " + ChessMoves.GetChessMovesString(validMoves));
        }
    }
}
