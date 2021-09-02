using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Knight : Figure   
    {
        public Field Field { get; set; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public Knight(Field field, char mark, Color color) : base(color, field, mark)
        {
            //Field = field;
            //Color = color;
            //if (color == Color.WHITE)
            //{
            //    Mark = Char.ToLower(mark);
            //}
            //else
            //{
            //    Mark = Char.ToUpper(mark);
            //}
            //EnPassantCheck = false;
            //Eaten = false;
        }


        public override bool MoveCheck(Field f1) => this.Field.CalculateFieldDistance(f1) == 3 && !this.Field.CheckSameColumn(f1) && !this.Field.CheckSameRow(f1);
        public override bool MoveCheck(Field f1, Chessboard chessboard) => MoveCheck(f1);
        public override bool NoFigureInPath(Field f1, Chessboard chessboard) => true;

        
    }
}
