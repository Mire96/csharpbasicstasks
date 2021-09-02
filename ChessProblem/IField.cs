using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProblem
{
    public interface IField
    {
        public char Column { get; set; }
        public int Row { get; set; }
        public IFigure Figure { get; set; }
    }
}
