using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCodeLogic.Example4
{
    public class RomanNumeralConverter
    {
        private static readonly (int Value, string Symbol)[] RomanMap =
        {
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I")
        };

        private static readonly Dictionary<char, int> RomanValues = new()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        public string ToRoman(int number)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            var result = new StringBuilder();

            foreach (var item in RomanMap)
            {
                while (number >= item.Value)
                {
                    result.Append(item.Symbol);
                    number -= item.Value;
                }
            }

            return result.ToString();
        }

        public int ToInteger(string roman)
        {
            if (string.IsNullOrWhiteSpace(roman))
                throw new ArgumentException("Roman numeral is required.");

            roman = roman.ToUpper();

            int total = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                int current = RomanValues[roman[i]];

                if (i < roman.Length - 1)
                {
                    int next = RomanValues[roman[i + 1]];

                    if (current < next)
                    {
                        total -= current;
                        continue;
                    }
                }

                total += current;
            }

            return total;
        }
    }
}