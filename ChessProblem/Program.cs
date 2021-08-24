using System;

namespace ChessProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            Field f1 = new Field('a', 1);
            Field f2 = new Field('g', 5);
            Field f3 = new Field('e', 3);
            Field f4 = new Field('b', 2);
            Field f5 = new Field('d', 8);
            Field f6 = new Field('a', 3);

            IFigure fig1 = new Rook(f1, 'r', Color.WHITE);
            IFigure fig2 = new Bishop(f2, 'b', Color.WHITE);
            IFigure fig3 = new Queen(f3, 'q', Color.BLACK);
            IFigure fig4 = new Knight(f4, 'n', Color.BLACK);
            IFigure fig5 = new Rook(f5, 'r', Color.BLACK);

            

            Console.WriteLine(chessboard.PlacePiece(fig1));
            Console.WriteLine(chessboard.PlacePiece(fig1));
            Console.WriteLine(chessboard.PlacePiece(fig2));
            Console.WriteLine(chessboard.PlacePiece(fig3));
            Console.WriteLine(chessboard.PlacePiece(fig4));
            Console.WriteLine(chessboard.PlacePiece(fig5));

            chessboard.PrintCoordinates();
            chessboard.BoardPrint();
            Console.WriteLine(chessboard.MovePiece(fig1, f6));
            chessboard.BoardPrint();
            Console.WriteLine(chessboard.MovePiece(fig1, f3));
            chessboard.BoardPrint();
            chessboard.BoardWrite();



            //Field test = chessboard.FindFieldOnBoard(f1);

            //Console.WriteLine(test);

            //test.Row = 3;

            //Console.WriteLine(test);
            //chessboard.PrintCoordinates();







        }
    }
}
