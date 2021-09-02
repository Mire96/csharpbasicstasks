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

        public IField Field { get; set; }
        
        public char Mark {get; set;}

        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }


        public bool MoveCheck(IField f1);
        bool NoFigureInPath(IField f1, Chessboard chessboard);
        bool MoveCheck(IField f1, Chessboard chessboard);
    }
}
