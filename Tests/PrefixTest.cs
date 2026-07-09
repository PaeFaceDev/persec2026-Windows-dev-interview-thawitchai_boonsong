using InterviewCodeLogic.StartUp.Example_2;
using InterviewCodeLogic.StartUp.Example_2.Entity;
using Xunit;

namespace Tests
{
    public class PrefixTest
    {
        [Fact]
        public void SortArray_ShouldSortByNumberAfterPrefix()
        {
            Prefix prefix = new Prefix();

            PrefixRequest request = new PrefixRequest
            {
                Input = new[]
                {
                    "TH10",
                    "TH3Netflix",
                    "TH1",
                    "TH7"
                }
            };

            var result = prefix.SortArray(request);

            Assert.Equal(
                new[]
                {
                    "TH1",
                    "TH3Netflix",
                    "TH7",
                    "TH10"
                },
                result.Result
            );
        }
    }
}