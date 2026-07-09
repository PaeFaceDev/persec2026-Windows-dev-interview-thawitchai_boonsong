using System;
using System.Collections.Generic;

namespace InterviewCodeLogic.Example6
{
    public class Tribonacci
    {
        public List<int> Generate(List<int> seed, int count)
        {
            if (seed == null)
                throw new ArgumentNullException(nameof(seed));

            if (seed.Count > 3)
                throw new ArgumentException("Initial values must contain between 0 and 3 numbers.");

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var result = new List<int>(seed);

            while (result.Count < 3)
            {
                result.Add(0);
            }

            for (int i = 0; i < count; i++)
            {
                result.Add(result[^1] + result[^2] + result[^3]);
            }

            return result;
        }
        public void Print(List<int> numbers)
        {
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}