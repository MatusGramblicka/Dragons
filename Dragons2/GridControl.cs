using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    class GridControl
    {
        public static int recomputeRow(int row, int column)
        {
            if (column == 2)
                row++;

            return row;
        }

        public static int recomputeColumn(int column)
        {
            if (column == 2)
                column = 0;
            else
                column++;

            return column;
        }
    }
}
