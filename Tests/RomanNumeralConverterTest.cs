using System;
using InterviewCodeLogic.Example4;
using Xunit;

namespace Tests
{
    public class RomanNumeralConverterTest
    {
        [Theory]
        [InlineData(1989, "MCMLXXXIX")]
        [InlineData(2000, "MM")]
        [InlineData(68, "LXVIII")]
        [InlineData(109, "CIX")]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void ToRoman_ShouldConvertIntegerToRoman(
            int number,
            string expected)
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();

            var result = converter.ToRoman(number);

            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("MCMLXXXIX", 1989)]
        [InlineData("MM", 2000)]
        [InlineData("LXVIII", 68)]
        [InlineData("CIX", 109)]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        public void ToInteger_ShouldConvertRomanToInteger(
            string roman,
            int expected)
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();

            var result = converter.ToInteger(roman);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void ToRoman_WhenNumberIsZero_ShouldThrowException()
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                converter.ToRoman(0));
        }


        [Fact]
        public void ToRoman_WhenNumberIsNegative_ShouldThrowException()
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                converter.ToRoman(-10));
        }


        [Fact]
        public void ToInteger_WhenRomanIsEmpty_ShouldThrowException()
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();

            Assert.Throws<ArgumentException>(() =>
                converter.ToInteger(""));
        }
    }
}