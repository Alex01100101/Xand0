using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xand0
{
    public class Position
    {
        public int Row;
        public int Column;

        public int getRow()
        {
           return Row;
        }

        public void setRow(int row)
        {
            this.Row = row;
        }

        public int getColumn()
        {
            return Column;
        }

        public void setColumn(int col)
        { 
            this.Column = col;
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool PositionIsValid()
        {
            return (Row >= 0 && Row <= 3) && (Column >= 0 && Column <= 3);
        }
    }
}
