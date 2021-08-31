using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Milosev komentar
//Dodat komentar za test 1

namespace ChessProblem
{
    class King : IFigure
    {
        public Field Field { get ; set ; }
        public char Mark { get ; set ; }
        public Color Color { get ; set ; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public King(Field field, char mark, Color color)
        {
            Field = field;
            if (color == Color.WHITE)
            {
                Mark = Char.ToLower(mark);
            }
            else
            {
                Mark = Char.ToUpper(mark);
            }
            Color = color;
            EnPassantCheck = false;
            Eaten = false;
        }


        public bool MoveCheck(Field f1)
        {
            return this.BasicKingMoveRules(f1);
        }

        private bool BasicKingMoveRules(Field f1) 
        {
            return (this.Field.CheckSameDiagonal(f1) && this.Field.CalculateFieldDistance(f1) == 2) || ((this.Field.CheckSameRow(f1) || this.Field.CheckSameColumn(f1)) && this.Field.CalculateFieldDistance(f1) == 1);
        }

        public bool NoFigureInPath(Field f1, Chessboard chessboard)
        {
            return true;
        }

        public bool MoveCheck(Field f1, Chessboard chessboard)
        {
            if (BasicKingMoveRules(f1) && CheckForCheck(f1, chessboard))
            {
                return true;
            }

            Console.WriteLine("That field is being attacked by a figure of the opposite color");
            return false;
        }

        private bool CheckForCheck(Field f1, Chessboard chessboard)
        {
            foreach(IFigure CheckingFigure in chessboard.Figures)
            {
                if (this.Color != CheckingFigure.Color && CheckingFigure.MoveCheck(f1, chessboard) &&  CheckingFigure.NoFigureInPath(f1, chessboard)) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
