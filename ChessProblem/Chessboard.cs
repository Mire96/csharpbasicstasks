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
                    Field field = new Field(column: (char)(j + 65), row:i + 1);
                    testBoard[i, j] = field;
                }
            }

            this.Board = testBoard;
        }

        public void BoardPrint()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
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
                Console.WriteLine();
            }
        }

        public void BoardWrite()
        {
            string path = @"C:\Users\mmirkov\OneDrive - Orion Systems Integrators, LLC\Desktop\.Net Obuka\Basics\ChessProblem\ChessProblem\ChessProblem\chessboardfile.txt";
            using (FileStream ChessBoardFile = File.Open(path, FileMode.OpenOrCreate))
            {   
                ChessBoardFile.Seek(0, SeekOrigin.End);
                string lineToWrite = "\n";

                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if (Board[i, j].Figure == null)
                        {
                            lineToWrite += "* ";
                        }
                        else
                        {
                            lineToWrite += Board[i, j].Figure.Mark + " ";
                        }
                        
                    }
                    lineToWrite += "\n";
                    AddText(ChessBoardFile, lineToWrite);
                    lineToWrite = "";

                }
                AddText(ChessBoardFile, "End of table\n");
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

        public bool MovePiece(IFigure fig, Field field)
        {
            Field f1 = FindFieldOnBoard(field);
            if (fig.MoveCheck(f1))
            {
                if (CheckAvailableField(fig, f1))
                {
                    fig.Field.Figure = null;
                    fig.Field = f1;
                    f1.Figure = fig;
                    return true;
                }
                else
                {
                    if(DifferentColorCheck(fig, f1))
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

            return false;
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
