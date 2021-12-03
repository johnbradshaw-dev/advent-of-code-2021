using System;
using Xunit;


namespace AdventOfCode.Tests.Day3
{
    public class Day3Part2Tests
    {
        [Fact]
        public void Test1()
        {
            var input = 
             @"110000000000
             000000000001
             100000000000
             111000000000";

            var expectedOg = "111000000000";
            var expectedScrubber = "000000000001";
            var expected = Convert.ToInt32(expectedOg,2) * Convert.ToInt32(expectedScrubber, 2);
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part2();
            Assert.Equal(expected, res);
        }

        [Fact]
        public void Test2()
        {
            var input = 
             @"110000000000
             000000000001
             010000000001
             001000000001
             100000000000
             111000000000";

            var expectedOg = "111000000000";
            var expectedScrubber = "010000000001";
            var expected = Convert.ToInt32(expectedOg,2) * Convert.ToInt32(expectedScrubber, 2);
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part2();
            Assert.Equal(expected, res);
        }

        [Fact]
        public void example()
        {
            var input = 
             @"00100
                11110
                10110
                10111
                10101
                01111
                00111
                11100
                10000
                11001
                00010
                01010";

            var expectedOg = "10111";
            var expectedScrubber = "01010";
            var expected = Convert.ToInt32(expectedOg,2) * Convert.ToInt32(expectedScrubber, 2);
            var sut = new AdventOfCode2021.Day3(input);
            var res = sut.Part2();
            Assert.Equal(expected, res);
        }
    }
}
