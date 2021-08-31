using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public abstract class Figure : IFigure
    {
        public Color Color { get ; set ; }
        public Field Field { get; set; }
        public char Mark { get; set; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public abstract bool MoveCheck(Field f1);


        public abstract bool MoveCheck(Field f1, Chessboard chessboard);


        public abstract bool NoFigureInPath(Field f1, Chessboard chessboard);
        

        public Figure(Color color, Field field, char mark)
        {
            Color = color;
            Field = field;
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
    }
}
