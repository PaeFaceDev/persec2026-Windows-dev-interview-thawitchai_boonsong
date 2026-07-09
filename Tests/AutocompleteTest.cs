using InterviewCodeLogic.StartUp.Example_3;
using Xunit;

namespace Tests
{
    public class AutocompleteTest
    {
        [Fact]
        public void Search_ShouldReturnExpectedResult()
        {
            Autocomplete autocomplete = new Autocomplete();

            string[] items =
            {
                "Mother",
                "Think",
                "Worthy",
                "Apple",
                "Android"
            };

            var result = autocomplete.Search("th", items, 2);

            Assert.Equal(
                new[]
                {
                    "Think",
                    "Mother"
                },
                result);
        }
    }
}