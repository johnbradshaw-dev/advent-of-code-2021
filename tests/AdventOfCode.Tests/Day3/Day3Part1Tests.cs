using System;
using Xunit;


namespace AdventOfCode.Tests.Day3
{
    public class Day3Part1Tests
    {
        [Fact]
        public void AllOnesShouldReturnZero()
        {
            var input = 
            @"111111111111
            111111111111
            111111111111";
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part1();
            Assert.Equal(0,res);
        }

        [Fact]
        public void AllZerosShouldReturnZero()
        {
            var input = 
            @"000000000000
            000000000000
            000000000000";
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part1();
            Assert.Equal(0,res);
        }

        [Fact]
        public void ModeOfOneInFirstPositionShouldReturn1024()
        {
            var input = 
            @"100000000000
            100000000000
            000000000000";
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part1();
            Assert.Equal(4192256, res);
        }
        
    }
}
