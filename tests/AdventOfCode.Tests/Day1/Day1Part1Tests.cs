using System;
using Xunit;


namespace AdventOfCode.Tests.Day1
{
    public class Day1Part1Tests
    {
        [Fact]
        public void ListWithNoIncreaseShouldReturnZero()
        {
            var input = 
            @"1
            0";
            var sut = new AdventOfCode2021.Day1(input);
            var res = sut.Part1();
            Assert.Equal(res,0);
        }

        [Fact]
        public void ListWithOneIncreaseShouldReturn1()
        {
            var input = 
            @"1
            2";
            var sut = new AdventOfCode2021.Day1(input);
            var res = sut.Part1();
            Assert.Equal(res,1);
        }
    }
}
