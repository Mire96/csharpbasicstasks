using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessProblem
{
    public class Rook : IFigure
    {
        public IField Field { get ; set ; }
        public char Mark { get ; set ; }

        public Color Color { get; set; }
        public bool EnPassantCheck { get; set; }
        public bool Eaten { get; set; }

        public Rook(IField field, char mark, Color color)
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

        public bool MoveCheck(Field f1) => this.Field.CheckSameColumn(f1) || this.Field.CheckSameRow(f1);

        public bool MoveCheck(Field f1, Chessboard chessboard) => MoveCheck(f1);

        //if there is no figure in path the method returns true
        //It goes through the list of figures and as soon as it finds one where it can move to 
        //and the distance checker shows its between the moving piece and the destination field
        //it returns false, indicating that there is a figure in path
        public bool NoFigureInPath(Field f1, Chessboard chessboard)
        {
            foreach (IFigure figure in chessboard.Figures)
            {
                if (this.MoveCheck(figure.Field) && DistanceChecker(figure, f1))
                {
                    Console.WriteLine("There is a figure blocking the path to the field");
                    return false;
                }
            }
            return true;
        }


        //Distance checker checks if there is a figure between the moving piece and the destination field
        //If moving piece distance to figure is shorter than the distance to destination field
        //AND if destination field distance to figure is shorter than distance to destination field
        //THEN there is a figure between them and the piece cant move.
        //returns true - there is a figure in path
        //returns false - there isnt a figure in path
        private bool DistanceChecker(IFigure figure, Field f1)
        {
            int distance = this.Field.CalculateFieldDistance(f1);

            if (this.Field.CalculateFieldDistance(figure.Field) < distance &&
                f1.CalculateFieldDistance(figure.Field) < distance)
            {
                return true;
            }
            return false;
        }

        
    }
}
