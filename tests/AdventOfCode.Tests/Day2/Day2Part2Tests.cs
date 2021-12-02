using System;
using Xunit;


namespace AdventOfCode.Tests.Day2
{
    public class Day2Part2Tests
    {
        [Fact]
        public void DownTwiceAndForwardTwiceShouldReturn8()
        {
            var input = 
             @"down 2
             forward 2";
            var sut = new AdventOfCode2021.Day2(input);
            var res = sut.Part2();
            Assert.Equal(8, res);
        }
        public void DownTwiceAndForwardTwiceUpOnceForwardOnceShouldReturn8()
        {
            var input = 
             @"down 2
             forward 2
             up 1
             forward 1";
            var sut = new AdventOfCode2021.Day2(input);
            var res = sut.Part2();
            Assert.Equal(15, res);
        }
    }
}
