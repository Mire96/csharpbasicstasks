using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Bishop : IFigure
    {
        public Field Field { get ; set ; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }

        public Bishop(Field field, char mark, Color color)
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
        }

        public Bishop(char mark, Color color)
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

        public bool MoveCheck(Field f1)
        {
            return this.Field.CheckSameDiagonal(f1);
        }
    }
}
