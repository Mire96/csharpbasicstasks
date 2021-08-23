using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessProblem
{
    public class Rook : IFigure
    {
        public Field Field { get ; set ; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }
        
        public Rook(Field field, char mark, Color color)
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

        public Rook(char mark, Color color)
        {
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

        public bool MoveCheck(Field f1)
        {
            return this.Field.CheckSameColumn(f1) || this.Field.CheckSameRow(f1);
        }
        
    }
}
