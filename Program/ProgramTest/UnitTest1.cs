using System;
using Xunit;
using Program;


namespace ProgramTest
{
    public class UnitTest1
    {
        // Unit Testing
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void passingIsOdd(int value)
        {
            Assert.True(program.IsOdd(value));
        }

        [Fact]
        public void PassingAddTest()
        {
            Assert.Equal(6, program.Add(2, 4));
        }

        //Integration Testing
        int total = program.Square(program.Add(program.Multi(2, 3), 1));
        [Fact]
        public void multiFunction()
        {
            Assert.True(program.IsOdd(total));
            Assert.Equal(49, total);
        }
    }
}