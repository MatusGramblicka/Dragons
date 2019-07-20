using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragons2
{
    class GlobalMethods
    {
        /// <summary>
        /// Rotate colors in card name, eg. borv => vrob
        /// </summary>
        /// <param name="oldTag"></param>
        /// <returns></returns>
        public static string rotateColorsInCardName(string oldTag)
        {
            string firstLetterCardNumber = oldTag.Substring(0, 1);
            oldTag = oldTag.Substring(1);

            oldTag = Reverse(oldTag);

            return oldTag = firstLetterCardNumber + oldTag;
        }

        private static string Reverse(string s) // https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static char[] splitCardColor(string cardName)
        {
            cardName = cardName.Substring(1, 4);

            char[] charArray = cardName.ToCharArray();
           
            return charArray;
        }

        public static char getParticularSplitCardColor(string cardName, int index)
        {
            if (cardName.Substring(0, 1) == "a")        // it is action car, index must be zero, because after first letter removing, zero index will be color
                index = 0;

            cardName = cardName.Substring(1);           // remove first letter, it is number of various solors or letter a as action card

            char[] charArray = cardName.ToCharArray();

            return charArray[index];
        }

        public static bool checkColorMatch(char upperLeftColor, char upNeighborLowerLeftColor)
        {
            if (upperLeftColor.Equals(upNeighborLowerLeftColor))
                return true;
            else
                return false;
        }

        public static string getCardFromDeck(List<String> cards)
        {
            return cards[0];
        }

        /// <summary>
        /// Is there on the place where player want to put card already another card ?
        /// </summary>
        /// <param name="cellInput">Cell which was chosen for player´s card put on</param>
        /// <returns></returns>
        public static bool existAnotherCard(PictureBox clickedImage)
        {
            if (clickedImage.Name != null)
            {
                string dragonCardFirstLetter = clickedImage.Name.Substring(0, 1);

                return (dragonCardFirstLetter == "4" || dragonCardFirstLetter == "3" || dragonCardFirstLetter == "2" || dragonCardFirstLetter == "1");
            }

            return false;                           
        }
    }
}
