using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Queen : IFigure
    {
        public Field Field { get ; set ; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }

        public Queen(Field field, char mark, Color color)
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

        public bool MoveCheck(Field f1)
        {
            return Field.CheckSameDiagonal(f1) || Field.CheckSameColumn(f1) || Field.CheckSameRow(f1);

        }
    }
}
