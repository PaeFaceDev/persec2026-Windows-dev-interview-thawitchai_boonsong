using System;
using System.Collections.Generic;
using InterviewCodeLogic.Example6;
using Xunit;

namespace Tests
{
    public class TribonacciTest
    {
        [Fact]
        public void Generate_ShouldReturnCorrectSequence()
        {
            Tribonacci tribonacci = new Tribonacci();

            var result = tribonacci.Generate(
                new List<int> { 1, 3, 5 },
                5);

            Assert.Equal(
                new List<int>
                {
                    1,
                    3,
                    5,
                    9,
                    17,
                    31,
                    57,
                    105
                },
                result);
        }


        [Fact]
        public void Generate_WhenSeedHasTwoValues_ShouldFillZero()
        {
            Tribonacci tribonacci = new Tribonacci();

            var result = tribonacci.Generate(
                new List<int> { 1, 2 },
                3);

            Assert.Equal(
                new List<int>
                {
                    1,
                    2,
                    0,
                    3,
                    5,
                    8
                },
                result);
        }


        [Fact]
        public void Generate_WithThreeSameSeed_ShouldReturnCorrectSequence()
        {
            Tribonacci tribonacci = new Tribonacci();

            var result = tribonacci.Generate(
                new List<int> { 2, 2, 2 },
                3);

            Assert.Equal(
                new List<int>
                {
                    2,
                    2,
                    2,
                    6,
                    10,
                    18
                },
                result);
        }


        [Fact]
        public void Generate_WhenSeedIsNull_ShouldThrowException()
        {
            Tribonacci tribonacci = new Tribonacci();

            Assert.Throws<ArgumentNullException>(() =>
                tribonacci.Generate(null, 5));
        }


        [Fact]
        public void Generate_WhenSeedMoreThanThree_ShouldThrowException()
        {
            Tribonacci tribonacci = new Tribonacci();

            Assert.Throws<ArgumentException>(() =>
                tribonacci.Generate(
                    new List<int> { 1, 2, 3, 4 },
                    5));
        }


        [Fact]
        public void Generate_WhenCountIsNegative_ShouldThrowException()
        {
            Tribonacci tribonacci = new Tribonacci();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                tribonacci.Generate(
                    new List<int> { 1, 2, 3 },
                    -1));
        }
    }
}