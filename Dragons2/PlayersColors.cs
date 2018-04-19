using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragons2
{
    class PlayersColors
    {
        public static LinkedList<String> listToLinkedList(List<string> dragonsColorsList)
        {
            LinkedList<String> dragonsColorsLocal = new LinkedList<string>();

            for (int i = 0; i < dragonsColorsList.Count; i++)
                dragonsColorsLocal.AddLast(dragonsColorsList[i]);

            return dragonsColorsLocal;
        }

        public static List<string> LinkedListToList(LinkedList<string> dragonsColorsLinkedList)
        {
            List<String> localList = new List<string>();

            int repetition = dragonsColorsLinkedList.Count;

            for(int i = 0; i < repetition; i++)
            {
                localList.Add(dragonsColorsLinkedList.First.Value.ToString());
                dragonsColorsLinkedList.RemoveFirst();
            }

            return localList;
        }
    }
}
