using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if ((this.Field.CheckSameDiagonal(f1) && this.Field.CalculateFieldDistance(f1) == 2) ||
                ((this.Field.CheckSameRow(f1) || this.Field.CheckSameColumn(f1)) && this.Field.CalculateFieldDistance(f1) == 1))
            {
                return true;
            }
            return false;
        }
    }
}
