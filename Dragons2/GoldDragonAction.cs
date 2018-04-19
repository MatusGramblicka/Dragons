using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    class GoldDragonAction
    {
        public static bool GoldDragonActionFlag = false;
        /// <summary>
        /// Get number that represents index of opponent card
        /// </summary>
        /// <param name="objname"></param>
        /// <returns></returns>
        public static int getCardNumber(string objname)
        {
            objname = objname.Substring(objname.Length - 1);

            return int.Parse(objname);
        }
    }
}
