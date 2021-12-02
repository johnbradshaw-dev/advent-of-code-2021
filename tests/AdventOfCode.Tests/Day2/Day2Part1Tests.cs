using System;
using Xunit;


namespace AdventOfCode.Tests.Day2
{
    public class Day2Part1Tests
    {
        [Fact]
        public void MovingOnceForwardAndOnceDownShouldReturn1()
        {
            var input = 
            @"forward 1
            down 1";
            var sut = new AdventOfCode2021.Day2(input);
            var res = sut.Part1();
            Assert.Equal(1,res);
        }

        [Fact]
        public void MovingTwiceForwardAndTwiceDownShouldReturn4()
        {
            var input = 
            @"forward 2
            down 2";
            var sut = new AdventOfCode2021.Day2(input);
            var res = sut.Part1();
            Assert.Equal(4,res);
        }

        [Fact]
        public void MovingTwiceForwardAndOnceDownAndOnceBackShouldReturn0()
        {
            var input = 
            @"forward 2
            down 1
            up 1";
            var sut = new AdventOfCode2021.Day2(input);
            var res = sut.Part1();
            Assert.Equal(0,res);
        }
        
    }
}
