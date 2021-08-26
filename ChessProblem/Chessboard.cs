using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChessProblem
{
    public class Chessboard
    {
        public Field [,] Board { get; set; }
        public List<IFigure> Figures { get; set; }
        public List<IFigure> EatenFigures { get; set; }

        

        public Chessboard()
        {
            Figures = new List<IFigure>();
            EatenFigures = new List<IFigure>();
            Field [,] testBoard = new Field[8, 8];
            for(int i = 0; i < testBoard.GetLength(0); i++) 
            { 
                for(int j = 0; j < testBoard.GetLength(1); j++)
                {
                    Field field = new Field(column: (char)(j + 65), row:8-i);
                    testBoard[i, j] = field;
                }
            }

            this.Board = testBoard;
            InitBoard();


        }

        private void InitBoard()
        {
            Field f1 = new Field('a', 1);
            Field f2 = new Field('b', 1);
            Field f3 = new Field('c', 1);
            Field f4 = new Field('d', 1);
            Field f5 = new Field('e', 1);
            Field f6 = new Field('f', 1);
            Field f7 = new Field('g', 1);
            Field f8 = new Field('h', 1);
            Field f9 = new Field('a', 8);
            Field f10 = new Field('b', 8);
            Field f11 = new Field('c', 8);
            Field f12 = new Field('d', 8);
            Field f13= new Field('e', 8);
            Field f14= new Field('f', 8);
            Field f15= new Field('g', 8);
            Field f16= new Field('h', 8);

            IFigure fig1 = new Rook(f1, 'r', Color.WHITE);
            IFigure fig2 = new Knight(f2, 'n', Color.WHITE);
            IFigure fig3 = new Bishop(f3, 'b', Color.WHITE);
            IFigure fig4 = new Queen(f4, 'q', Color.WHITE);
            IFigure fig5 = new King(f5, 'k', Color.WHITE);
            IFigure fig6 = new Bishop(f6, 'b', Color.WHITE);
            IFigure fig7 = new Knight(f7, 'n', Color.WHITE);
            IFigure fig8 = new Rook(f8, 'r', Color.WHITE);

            IFigure fig9 = new Rook(f9, 'r', Color.BLACK);
            IFigure fig10 = new Knight(f10, 'n', Color.BLACK);
            IFigure fig11= new Bishop(f11, 'b', Color.BLACK);
            IFigure fig12= new Queen(f12, 'q', Color.BLACK);
            IFigure fig13= new King(f13, 'k', Color.BLACK);
            IFigure fig14= new Bishop(f14, 'b', Color.BLACK);
            IFigure fig15= new Knight(f15, 'n', Color.BLACK);
            IFigure fig16= new Rook(f16, 'r', Color.BLACK);


            PlacePiece(fig1);
            PlacePiece(fig2);
            PlacePiece(fig3);
            PlacePiece(fig4);
            PlacePiece(fig5);
            PlacePiece(fig6);
            PlacePiece(fig7);
            PlacePiece(fig8);
            PlacePiece(fig9);
            PlacePiece(fig10);
            PlacePiece(fig11);
            PlacePiece(fig12);
            PlacePiece(fig13);
            PlacePiece(fig14);
            PlacePiece(fig15);
            PlacePiece(fig16);
        }

        public void BoardPrint()
        {
            Console.WriteLine("  A B C D E F G H");
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    
                    if (Board[i, j].Figure == null)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(Board[i, j].Figure.Mark + " ");
                    }
                }
                Console.Write((8 - i));
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public void BoardWrite()
        {
            string path = @"C:\Users\mmirkov\OneDrive - Orion Systems Integrators, LLC\Desktop\.Net Obuka\Basics\ChessProblem\ChessProblem\ChessProblem\chessboardfile.txt";
            using (FileStream ChessBoardFile = File.Open(path, FileMode.OpenOrCreate))
            {   
                ChessBoardFile.Seek(0, SeekOrigin.End);

                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if (Board[i, j].Figure == null)
                        {
                            AddText(ChessBoardFile, "* ");
                        }
                        else
                        {
                            AddText(ChessBoardFile, (Board[i, j].Figure.Mark + " "));
                        }
                        AddText(ChessBoardFile, "\n");

                    }

                }
                AddText(ChessBoardFile, "End of table");
                Console.WriteLine("File written successfully");
            }
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
            
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public void PrintCoordinates()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
        }

        public bool PlacePiece(IFigure figure)
        {
            Field fieldToCheck = FindFieldOnBoard(figure.Field);

            if (CheckAvailableField(figure, fieldToCheck))
            {   
                fieldToCheck.Figure = figure;
                figure.Field = fieldToCheck;
                Figures.Add(figure);
                return true;
            }
            return false;
        }

        private bool CheckAvailableField(IFigure fig, Field field)
        {
            if (field.Figure == null)
            {
                return true;
            }
            return false;
        }

        private bool NoFigureInPath(IFigure fig, Field field)
        {
            if (fig.Mark == 'n' || fig.Mark == 'N')
            {
                return true;
            }

            return false;
            
        }

        public bool MovePiece(Field pieceField, Field destinationField)
        {
            IFigure fig = FindPieceOnBoard(pieceField);
            Field f1 = FindFieldOnBoard(destinationField);

            if(fig == null || f1 == null)
            {
                Console.WriteLine("Piece or field not found on board. Try again");
                return false;
            }

            if (fig.MoveCheck(f1,this))
            {
                if (fig.NoFigureInPath(f1, this)){
                    if (CheckAvailableField(fig, f1))
                    {
                        fig.Field.Figure = null;
                        fig.Field = f1;
                        f1.Figure = fig;
                        return true;
                    }
                    else
                    {
                        if (DifferentColorCheck(fig, f1))
                        {
                            EatenFigures.Add(f1.Figure);
                            fig.Field.Figure = null;
                            fig.Field = f1;
                            f1.Figure = fig;
                            Console.WriteLine("Figure eaten");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Another piece of the same color occupies the field");
                            return false;
                        }
                    }
                }
                
                
            }

            return false;
        }


        private IFigure FindPieceOnBoard(Field pieceField)
        {
            foreach(IFigure figure in Figures)
            {
                if (figure.Field.Equals(pieceField))
                {
                    return figure;
                }
            }
            return null;
        }

        private bool DifferentColorCheck(IFigure fig, Field f1)
        {
            return fig.Color != f1.Figure.Color;
        }

        public Field FindFieldOnBoard(Field field) 
        { 
            foreach(Field f in Board)
            {
                if (field.Equals(f))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
