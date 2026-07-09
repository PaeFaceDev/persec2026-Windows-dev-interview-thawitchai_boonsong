using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCodeLogic.StartUp.Example_1;
using InterviewCodeLogic.StartUp.Example_1.Entity;
using Xunit;

namespace Tests
{
    public class IsValidTests
    {
        [Fact]
        public void CheckInputInvalidShouldReturnFalse()
        {
            IsValid isValid = new IsValid();

            bool result = isValid.CheckIsValid(new InputType()
            {
                Input = ")"
            });

            Assert.False(result);
        }
        [Fact]
        public void CheckInputInvalidShouldReturnTrue()
        {
            IsValid isValid = new IsValid();

            bool result = isValid.CheckIsValid(new InputType()
            {
                Input = "([{}])"
            });

            Assert.True(result);
        }
    }
}