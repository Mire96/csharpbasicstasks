using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Autofac;

namespace ChessProblem
{
    public class Chessboard
    {
        public Field [,] Board { get; set; }
        public List<IFigure> Figures { get; set; }
        public List<IFigure> EatenFigures { get; set; }
        public Color Turn { get; set; }

        

        public Chessboard()
        {
            Figures = new List<IFigure>();
            EatenFigures = new List<IFigure>();
            Turn = Color.WHITE;
            Field [,] testBoard = new Field[8, 8];
            for(int i = 0; i < testBoard.GetLength(0); i++) 
            { 
                for(int j = 0; j < testBoard.GetLength(1); j++)
                {
                    Field field = new Field(column: (char)(j + 65), row:8-i, Color.WHITE, "");
                    testBoard[i, j] = field;
                }
            }

            this.Board = testBoard;
            InitBoard();


        }

        private void InitBoard()
        {
            ContainerBuilder objContainer = new ContainerBuilder();
            objContainer.RegisterType<Field>()
                        .As<IField>();
         
            IContainer Container = objContainer.Build();

            IField f1 = Container.Resolve<IField>();
            IField f2 = Container.Resolve<IField>();
            IField f3 = Container.Resolve<IField>();
            IField f4 = Container.Resolve<IField>();
            IField f5 = Container.Resolve<IField>();
            IField f6 = Container.Resolve<IField>();
            IField f7 = Container.Resolve<IField>();
            IField f8 = Container.Resolve<IField>();
            IField f9 = Container.Resolve<IField>();
            IField f10 = Container.Resolve<IField>();
            IField f11 = Container.Resolve<IField>();
            IField f12 = Container.Resolve<IField>();
            IField f13= Container.Resolve<IField>();
            IField f14= Container.Resolve<IField>();
            IField f15= Container.Resolve<IField>();
            IField f16= Container.Resolve<IField>();

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

            InitPawns();


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

        private void InitPawns()
        {
            
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    PlacePiece(new Pawn(Color.WHITE, Board[6, j]));
                    PlacePiece(new Pawn(Color.BLACK, Board[1, j]));
            }
                
            
        }

        internal void ChangeTurn()
        {
            if(this.Turn == Color.WHITE)
            {
                this.Turn = Color.BLACK;
            }
            else
            {
                this.Turn = Color.WHITE;
            }
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

        public bool CheckAvailableField(IFigure fig, Field field)
        {
            if (field.Figure == null)
            {
                return true;
            }
            return false;
        }

        private bool ExecuteMove(IFigure FigureToMove, Field DestinationField) 
        {
            bool isMoveExecuted = false;

            if (FigureToMove.MoveCheck(DestinationField, this) &&
               FigureToMove.NoFigureInPath(DestinationField, this) &&
               (CheckAvailableField(FigureToMove, DestinationField) || DifferentColorCheck(FigureToMove, DestinationField)))
            {
                RemoveEatenFigures(FigureToMove);
                Move(FigureToMove, DestinationField);
                isMoveExecuted = true;

            }
            return isMoveExecuted;
        }



        private bool IsCanBeMoveExecuted(IFigure FigureToMove, Field DestinationField) 
        {
            bool isMoveCanBeExecuted = true;
            if (IsFigureOrFieldNotFound(FigureToMove, DestinationField) ||
               IsNotCorrectColorTurn(FigureToMove) ||
               IsKingInCheck())
            {
                isMoveCanBeExecuted = false;
            }

            return isMoveCanBeExecuted;
        }

        public bool MovePiece(Field pieceField, Field destinationField)
        {
            //bool IsPieceCanBeMove = false;
            //bool IsPieceMoved = false;
            IFigure FigureToMove = FindPieceOnBoard(pieceField);
            Field DestinationField = FindFieldOnBoard(destinationField);

            return IsCanBeMoveExecuted(FigureToMove, DestinationField) && ExecuteMove(FigureToMove, DestinationField);

            //IsPieceCanBeMove = IsCanBeMoveExecuted(FigureToMove, DestinationField);
            //if (IsPieceCanBeMove)
            //{
            //    IsPieceMoved = ExecuteMove(FigureToMove, DestinationField);
            //}
            //Console.WriteLine("Illegal move with the piece");
            //return IsPieceMoved;
        }

        private bool IsNotCorrectColorTurn(IFigure figureToMove)
        {
            if (figureToMove.Color != this.Turn)
            {
                Console.WriteLine("It's not " + figureToMove.Color + "'s turn to move. Choose a " + this.Turn + " figure");
                return true;
            }
            return false;
        }

        private bool IsFigureOrFieldNotFound(IFigure figureToMove, Field destinationField)
        {
            if (figureToMove == null || destinationField == null)
            {
                Console.WriteLine("Piece or field not found on board. Try again");
                return true;
            }
            return false;
        }

        private bool IsKingInCheck()
        {
            IFigure King = Figures.Find(x => (x.Mark == 'k' || x.Mark == 'K') && x.Color == this.Turn);
            foreach (IFigure CheckingFigure in Figures)
            {
                if (King.Color != CheckingFigure.Color && CheckingFigure.MoveCheck(King.Field, this) && CheckingFigure.NoFigureInPath(King.Field, this))
                {
                    Console.WriteLine(this.Turn + "'s King is in check, you have to move him");
                    return true;
                }
            }
            return false;
        }

        

        public void UncheckEnPassant()
        {
            foreach(IFigure figure in Figures)
            {
                if(figure.Color != this.Turn && figure.EnPassantCheck == true)
                {
                    figure.EnPassantCheck = false;
                }
            }
        }

        private void RemoveEatenFigures(IFigure FigureToMove)
        {
            IFigure figureToRemove = null;
            foreach (IFigure figure in this.Figures)
            {
                if (figure.Eaten)
                {
                    figureToRemove = figure;
                    break;
                }
            }
            if(figureToRemove != null && figureToRemove.Field != null)
            {
                Console.WriteLine(figureToRemove.Mark + figureToRemove.Field.ToString() + " eaten by " + FigureToMove.Mark);
                figureToRemove.Field.Figure = null;
                figureToRemove.Field = null;
                EatenFigures.Add(figureToRemove);
                Figures.Remove(figureToRemove);
            }
            
        }

        private void Move(IFigure FigureToMove, Field DestinationField)
        {
            FigureToMove.Field.Figure = null;
            FigureToMove.Field = DestinationField;
            DestinationField.Figure = FigureToMove;
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
            if(fig.Color != f1.Figure.Color)
            {
                f1.Figure.Eaten = true;
                return true;
            }
            Console.WriteLine("Another piece of the same color occupies the field");
            return false;
        }

        public Field FindFieldOnBoard(IField field) 
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
