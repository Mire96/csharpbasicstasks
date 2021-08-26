using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public interface IFigure
    {
        public Color Color { get; set; }

        public Field Field { get; set; }
        
        public char Mark {get; set;}


        public bool MoveCheck(Field f1);
        bool NoFigureInPath(Field f1, Chessboard chessboard);
        bool MoveCheck(Field f1, Chessboard chessboard);
    }
}
