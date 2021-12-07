using System;
using Xunit;


namespace AdventOfCode.Tests.Day6
{
    public class Day6Part1Tests
    {
        [Fact]
        public void ExampleData()
        {
            var input = 
            @"3,4,3,1,2";
            var sut = new AdventOfCode2021.Day6(input);
            var res = sut.Part1();
            Assert.Equal(5934,res);
        }

        [Fact]
        public void ExampleData2()
        {
            var input = 
            @"3,4,3,1,2";
            var sut = new AdventOfCode2021.Day6(input);
            var res = sut.Part1(18);
            Assert.Equal(26,res);
        }

        [Fact]
        public void Parsing()
        {
            var input = 
            @"3,4,3,1,2";
            var sut = new AdventOfCode2021.Day6(input);
            Assert.Equal(5,sut.Fish.Count);
        }
    }
}