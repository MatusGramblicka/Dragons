using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    public class Players
    {
        public Players(int playerNumber, int round)
        {
            this.playerNumber = playerNumber + 1;
            this.round = round;
        }

        private int playerNumber;
        public int PlayerNumber { get; set; }

        private int round;
        public int Round { get; set; }

        private int position;
        public int Position { get; set; }


        private string playerDragonColor;
        public string PlayerDragonColor { get; set; }

        public List<string> playersCards = new List<string>();

        public string getMessage()
        {
            //playerNumber += 1;
            round += 1;     // this should be counted in other way

            string message = "Playing " + playerNumber + " player, round number " + round + ".";
            return message;
        }
    }
}
