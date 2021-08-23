using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public class Field
    {
        public char Column { get; set;}
        public int Row { get; set; }
        public IFigure Figure { get => figure; set => figure = value; }

        private IFigure figure = null;

        public Field(char column, int row)
        {
            Column = Char.ToUpper(column);
            Row = row;
        }
        
        public Field()
        {
        }

        public bool CheckSameColumn(Field f1) => f1.Column == this.Column;
        
        public bool CheckSameRow(Field f1) => f1.Row == this.Row;

        public bool CheckSameDiagonal(Field f1) => Math.Abs(f1.Row - this.Row) == Math.Abs(f1.Column - this.Column);

        public int CalculateFieldDistance(Field f1) => Math.Abs(f1.Row - this.Row) + Math.Abs(f1.Column - this.Column);

        public override string ToString() => this.Column + this.Row.ToString();

        public override bool Equals(object obj)
        {
            Field field = (Field)obj;
            return this.Column == field.Column && this.Row == field.Row;
        }
    }
}
