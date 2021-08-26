using System;

namespace ChessProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            Console.WriteLine("Input piece coordinates followed by coordinates of the field where you want to move.\n\nExample a1 a2, where a1 is the field where the piece is located and a2 is the destination");
            Console.WriteLine("\nAre you ready to begin a game?");
            Console.WriteLine("\nPress enter to start");
            Console.ReadLine();
            chessboard.PrintCoordinates();                   

            while (true)
            {
                Console.Clear();
                chessboard.BoardPrint();
                Console.WriteLine("Input next move");
                try
                {
                    string moveCoordinates = Console.ReadLine();
                    string pieceCoordinates = moveCoordinates.Split(' ')[0];
                    string destinationCoordinates = moveCoordinates.Split(' ')[1];
                    Field PieceField = new Field(pieceCoordinates);
                    Field DestinationField = new Field(destinationCoordinates);
                    bool moveCheck = chessboard.MovePiece(PieceField, DestinationField);

                    if (moveCheck)
                    {
                        Console.WriteLine("MOVE SUCCESSFUL");
                    }
                    else
                    {
                        Console.WriteLine("MOVE FAILED");
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Please keep true to the format provided in the example");
                    Console.WriteLine("Press enter to return to the game and input a new move");
                    Console.ReadLine();
                    
                }



            }
            //chessboard.BoardWrite();

            //Field test = chessboard.FindFieldOnBoard(f1);

            //Console.WriteLine(test);

            //test.Row = 3;

            //Console.WriteLine(test);
            //chessboard.PrintCoordinates();







        }
    }
}
