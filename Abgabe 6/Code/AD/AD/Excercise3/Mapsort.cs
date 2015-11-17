using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise3
{
    public class Mapsort : ISorter
    {
        public void Sort(int[] array)
        {
            Sort(array, 1.5);
        }

        private void Swap(int[] array, int a, int b)
        {
            int temp = array[a];

            array[a] = array[b];
            array[b] = temp;
        }

        private void Sort(int[] array, double c)
        {
            const int undefined = -1;

            // neuen array der länge n * c mit -1 füllen
            int tempArrayLength = (int)(array.Length * c);
            var tempArray = new int[tempArrayLength].Select(x => undefined).ToArray();

            int max = array.Max(),
                min = array.Min();

            // distanz bestimmen
            double dist = (double)(max - min) / (tempArray.Length - 1);

            for (int i = 0; i < array.Length; i++)
            {
                // elemente aus a in temporären array einordnen
                int targetPosition = (int)((array[i] - min) / dist),
                    insert = array[i];
                
                bool searchLeft = false;

                // falls belegt --> nach links suchen
                if (tempArray[targetPosition] != -1 && insert <= tempArray[targetPosition])
                {
                    searchLeft = true;
                }

                // solange belegt --> freie stelle suchen
                while (tempArray[targetPosition] != -1)
                {
                    if (searchLeft)
                    {
                        if (insert > tempArray[targetPosition])
                        {
                            Swap(tempArray, targetPosition, insert);
                        }

                        if (targetPosition > 0)
                        {
                            targetPosition--;
                        }
                        else
                        {
                            searchLeft = false;
                        }
                    }
                    else
                    {
                        if (insert <= tempArray[targetPosition])
                        {
                            Swap(tempArray, targetPosition, insert);
                        }

                        if (targetPosition < tempArray.Length - 1)
                        { 
                            targetPosition++; 
                        }
                        else
                        {
                            searchLeft = true;
                        }
                    }
                }

                tempArray[targetPosition] = insert;
            }

            // filtern der undefinierten werte und kopieren des 
            // temporären arrays in den originalen array
            tempArray = tempArray.Where(x => x != undefined).ToArray();
            Array.Copy(tempArray, array, tempArray.Length);
        }

    }
}
