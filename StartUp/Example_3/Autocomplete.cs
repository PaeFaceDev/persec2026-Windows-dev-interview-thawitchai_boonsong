using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCodeLogic.StartUp.Example_3
{
    public class Autocomplete
    {
        public string[] Search(string search, string[] items, int maxResult)
        {
            search = search.ToLower();

            var starts = items
                .Where(x => x.StartsWith(search, StringComparison.OrdinalIgnoreCase));

            var middle = items
                .Where(x =>
                    x.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                    !x.StartsWith(search, StringComparison.OrdinalIgnoreCase) &&
                    !x.EndsWith(search, StringComparison.OrdinalIgnoreCase));

            var ends = items
                .Where(x =>
                    x.EndsWith(search, StringComparison.OrdinalIgnoreCase) &&
                    !x.StartsWith(search, StringComparison.OrdinalIgnoreCase));

            return starts
                .Concat(middle)
                .Concat(ends)
                .Take(maxResult)
                .ToArray();
        }
    }
}