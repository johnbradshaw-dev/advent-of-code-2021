using System;
using Xunit;


namespace AdventOfCode.Tests.Day1
{
    public class Day1Part2Tests
    {
        [Fact]
        public void ListWithNoIncreaseShouldReturnZero()
        {
            var input = 
            @"1
            2
            3
            1";
            var sut = new AdventOfCode2021.Day1(input);
            var res = sut.Part2();
            Assert.Equal(res,0);
        }

        [Fact]
        public void ListWithOneIncreaseShouldReturn1()
        {
            var input = 
            @"1
            2
            3
            2";
            var sut = new AdventOfCode2021.Day1(input);
            var res = sut.Part2();
            Assert.Equal(res,1);
        }
    }
}
