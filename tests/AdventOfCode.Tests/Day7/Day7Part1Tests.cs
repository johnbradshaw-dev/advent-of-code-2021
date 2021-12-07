using System;
using Xunit;


namespace AdventOfCode.Tests.Day7
{
    public class Day7Part1Tests
    {
        [Fact]
        public void ExampleData()
        {
            var input = 
            @"16,1,2,0,4,2,7,1,2,14";
            var sut = new AdventOfCode2021.Day7(input);
            var res = sut.Part1();
            Assert.Equal(37,res);
        }
    }
}