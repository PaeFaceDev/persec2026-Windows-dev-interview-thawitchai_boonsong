using System;
using InterviewCodeLogic.Example5;
using Xunit;

namespace Tests
{
    public class NumberSorterTest
    {
        [Theory]
        [InlineData(3008, 8300)]
        [InlineData(1989, 9981)]
        [InlineData(2679, 9762)]
        [InlineData(9163, 9631)]
        [InlineData(1234, 4321)]
        [InlineData(5555, 5555)]
        public void SortDescending_ShouldSortNumberFromHighToLow(
            int input,
            int expected)
        {
            NumberSorter sorter = new NumberSorter();

            var result = sorter.SortDescending(input);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void SortDescending_WhenNumberIsNegative_ShouldThrowException()
        {
            NumberSorter sorter = new NumberSorter();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                sorter.SortDescending(-1234));
        }


        [Fact]
        public void SortDescending_WhenNumberIsSingleDigit_ShouldReturnSameNumber()
        {
            NumberSorter sorter = new NumberSorter();

            var result = sorter.SortDescending(7);

            Assert.Equal(7, result);
        }
    }
}