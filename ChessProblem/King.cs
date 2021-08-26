using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Milosev komentar
<<<<<<< HEAD
//Dodat komentar za test 1

=======
//Adding comment for test 2
>>>>>>> 8153c59 (Commented test 2)
namespace ChessProblem
{
    class King : IFigure
    {
        public Field Field { get ; set ; }
        public char Mark { get ; set ; }
        public Color Color { get ; set ; }

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
        }


        public bool MoveCheck(Field f1)
        {
            return true;
        }

        private bool BasicKingMoveRules(Field f1) => (this.Field.CheckSameDiagonal(f1) && this.Field.CalculateFieldDistance(f1) == 2) ||
                ((this.Field.CheckSameRow(f1) || this.Field.CheckSameColumn(f1)) && this.Field.CalculateFieldDistance(f1) == 1);

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
            return false;
        }

        private bool CheckForCheck(Field f1, Chessboard chessboard)
        {
            foreach(IFigure CheckingFigure in chessboard.Figures)
            {
                if (CheckingFigure.MoveCheck(f1) && CheckingFigure.NoFigureInPath(f1, chessboard)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
