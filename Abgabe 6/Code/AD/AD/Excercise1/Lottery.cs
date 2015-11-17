using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Excercise1
{
    public class Lottery
    {
        private Random random;
        private RingList<int> list;

        public Lottery()
        {
            random = new Random();
            list = new RingList<int>();

            for (int i = 0; i < 49; i++)
            {
                list.Add(i + 1);
            }
        }

        public CustomLinkedList<int> ChooseNumbers(int n)
        {
            var takenNumbers = new CustomLinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                int index = random.Next(list.Count - 1),
                    number = list[index];

                takenNumbers.Add(number);
                list.Remove(number);
            }

            return takenNumbers;
        }
    }
}
