using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCodeLogic.StartUp.Example_2.Entity;

namespace InterviewCodeLogic.StartUp.Example_2
{
    public class Prefix
    {
        public string GetPrefix(string s)
        {
            int i = 0;
            while (i < s.Length && char.IsLetter(s[i]))
                i++;

            return s.Substring(0, i);
        }

        public int GetNumber(string s)
        {
            int i = 0;
            while (i < s.Length && char.IsLetter(s[i]))
                i++;

            int start = i;

            while (i < s.Length && char.IsDigit(s[i]))
                i++;

            return int.Parse(s.Substring(start, i - start));
        }

        public PrefixResponse SortArray(PrefixRequest request)
        {
            return new PrefixResponse
            {
                Result = request.Input
                    .OrderBy(GetPrefix)
                    .ThenBy(GetNumber)
                    .ToArray()
            };
        }
    }
}