using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    public class Coordinates
    {       
        public int Row { get; set; }
        public int Column { get; set; }
        public bool AlreadyAdded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="AlreadyAdded">Card was checked and color count was increased, so there is no need to add again</param>
        public Coordinates(int row, int column, bool alreadyAdded)
        {
            Row = row;
            Column = column;
            AlreadyAdded = alreadyAdded;
        }
    }
}
