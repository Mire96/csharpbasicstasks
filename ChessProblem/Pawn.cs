using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    class Pawn : IFigure
    {
        public Color Color { get; set; }
        public Field Field { get; set; }
        public char Mark { get; set; }

        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public Pawn(Color color, Field field)
        {
            Color = color;
            Field = field;
            if(color == Color.WHITE)
            {
                Mark = 'p';
            }
            else
            {
                Mark = 'P';
            }

            EnPassantCheck = false;
        }

        public bool MoveCheck(Field f1)
        {
            Console.WriteLine("THis method is deprecated");
            return true;
        }


        public bool MoveCheck(Field f1, Chessboard chessboard)
        {
            return ColumnMoveCheck(f1, chessboard) || DiagonalMoveCheck(f1, chessboard);
        }

        private bool ColumnMoveCheck(Field f1, Chessboard chessboard)
        {
            return SameColumnMove(f1) && ForwardMoveCheck(f1) && chessboard.CheckAvailableField(this, f1) ;
        }

        private bool SameColumnMove(Field f1)
        {
            return this.Field.CheckSameColumn(f1) && (OneFieldMove(f1) || TwoFieldMove(f1));
        }

        private bool OneFieldMove(Field f1)
        {
            return this.Field.CalculateFieldDistance(f1) == 1;
        }

        private bool TwoFieldMove(Field f1)
        {
            if(((this.Color == Color.WHITE && this.Field.Row == 2) ||
                (this.Color == Color.BLACK && this.Field.Row == 7)) 
                && this.Field.CalculateFieldDistance(f1) == 2)
            {
                this.EnPassantCheck = true;
                return true;
            }
            return false;
        }

        private bool ForwardMoveCheck(Field f1)
        {
            if((this.Color == Color.WHITE && this.Field.Row < f1.Row) || 
                (this.Color == Color.BLACK && this.Field.Row > f1.Row))
            {
                return true;
            }
            return false;
        }

        private bool DiagonalMoveCheck(Field f1, Chessboard chessboard)
        {
            return SameDiagonalMove(f1) && ForwardMoveCheck(f1) && PawnEatCheck(f1, chessboard);
        }

        private bool SameDiagonalMove(Field f1)
        {
            return (this.Field.CheckSameDiagonal(f1) && this.Field.CalculateFieldDistance(f1) == 2);
        }

        private bool PawnEatCheck(Field f1, Chessboard chessboard)
        {
            if(f1.Figure != null && f1.Figure.Color != this.Color)
            {
                return true;
            }
            else if(EnPassantMoveCheck(f1, chessboard)) {
                return true;
            }
            return false;
        }

        private bool EnPassantMoveCheck(Field f1, Chessboard chessboard)
        {
            foreach(IFigure figure in chessboard.Figures)
            {
                if(figure.Color != this.Color && figure.EnPassantCheck && EnPassantPositionCheck(f1, figure))
                {
                    figure.Eaten = true;
                    return true;
                }
            }
            return false;
        }

        private bool EnPassantPositionCheck(Field f1, IFigure figure)
        {
            if(figure.Field.CheckSameColumn(f1) && figure.Field.CheckSameRow(this.Field))
            {
                return true;
            }
            return false;
        }

        public bool NoFigureInPath(Field f1, Chessboard chessboard)
        {
            return true;
        }
    }
}
