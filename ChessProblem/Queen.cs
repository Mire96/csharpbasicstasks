using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Queen : IFigure
    {
        public IField Field { get ; set ; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public Queen(IField field, char mark, Color color)
        {
            Field = field;
            Color = color;
            if (color == Color.WHITE)
            {
                Mark = Char.ToLower(mark);
            }
            else
            {
                Mark = Char.ToUpper(mark);
            }
            EnPassantCheck = false;
            Eaten = false;
        }

        public Queen(char mark, Color color)
        {
            if (color == Color.WHITE)
            {
                Mark = Char.ToLower(mark);
            }
            else
            {
                Mark = Char.ToUpper(mark);
            }
            Color = color;
        }

        public bool MoveCheck(IField f1) => Field.CheckSameDiagonal(f1) || Field.CheckSameColumn(f1) || Field.CheckSameRow(f1);

        public bool MoveCheck(IField f1, Chessboard chessboard) => MoveCheck(f1);

        public bool NoFigureInPath(Field f1, Chessboard chessboard)
        {
            if (this.Field.CheckSameDiagonal(f1))
            {
                foreach (IFigure figure in chessboard.Figures)
                {
                    if(this.Field.CheckSameDiagonal(figure.Field) && DistanceChecker(figure, f1))
                    {
                        Console.WriteLine(Mark + " can't move because there is a figure in path");
                        return false;
                    }
                }
            }
            else 
            {
                foreach (IFigure figure in chessboard.Figures)
                {
                    if (MoveCheck(figure.Field) && DistanceChecker(figure, f1))
                    {
                        Console.WriteLine(Mark + " can't move because there is a figure in path");
                        return false;
                    }
                }
            }
            return true;

        }

        private bool DistanceChecker(IFigure figure, Field f1)
        {
            int distance = this.Field.CalculateFieldDistance(f1);

            if (this.Field.CalculateFieldDistance(figure.Field) < distance &&
                f1.CalculateFieldDistance(figure.Field) < distance)
            {
                return true;
            }
            return false;
        }

    }
}
