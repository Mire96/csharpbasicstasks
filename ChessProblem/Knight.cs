using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Knight : IFigure   
    {
        public IField Field { get; set; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public Knight(IField field, char mark, Color color)
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

        public Knight(char mark, Color color)
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

        public bool MoveCheck(Field f1) => this.Field.CalculateFieldDistance(f1) == 3 && !this.Field.CheckSameColumn(f1) && !this.Field.CheckSameRow(f1);
        public bool MoveCheck(Field f1, Chessboard chessboard) => MoveCheck(f1);
        public bool NoFigureInPath(Field f1, Chessboard chessboard) => true;

        
    }
}
