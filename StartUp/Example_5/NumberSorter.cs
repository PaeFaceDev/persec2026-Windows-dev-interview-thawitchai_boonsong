using System;
using System.Linq;

namespace InterviewCodeLogic.Example5
{
    public class NumberSorter
    {
        public int SortDescending(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            char[] digits = number.ToString().ToCharArray();

            Array.Sort(digits);
            Array.Reverse(digits);

            return int.Parse(new string(digits));
        }
    }
}