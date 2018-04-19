using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    static class DeckCards
    {
        public static string[] getDeckCards(string stringDeckCards)
        {
            string[] cardsToDeck = Directory.GetFiles(stringDeckCards, "*.png")
                                            .Select(Path.GetFileName)
                                            .ToArray();

            return cardsToDeck;
        }

        public static List<String> fillDeck(string[] cardsToDeck)
        {
            List<String> cards = new List<string>(66);

            for (int i = 0; i < cardsToDeck.Length; i++)
            {
                string cardName = cardsToDeck[i].Substring(0, cardsToDeck[i].Length - 4); // remove suffix .png
                cards.Add(cardName);
            }

            return cards;
        }

        public static List<string> fillPlayersColors(string[] startingDragons)
        {
            List<String> dragonsColors = new List<string>();

            for (int i = 0; i < startingDragons.Length; i++)
            {
                string cardName = startingDragons[i].Substring(0, startingDragons[i].Length - 4); // remove suffix .png
                dragonsColors.Add(cardName);
            }

            return dragonsColors;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
