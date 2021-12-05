using AdventOfCode2021;
using Xunit;

namespace AdventOfCode.Tests.Day5
{
    public class Day5ParserTests
    {
        [Fact]
        public void ParseStringToLine(){
            var line = "1,1 -> 1,1";
            var sut = new AdventOfCode2021.Day5(line);
            Assert.Contains<Line>(sut.Lines, l => l.Start == (1,1)&&l.End == (1,1));
        }

        [Fact]
        public void ParseComplexStringToLine(){
            var line = "1,2 -> 3,4";
            var sut = new AdventOfCode2021.Day5(line);
            Assert.Contains<Line>(sut.Lines, l => l.Start == (1,2)&&l.End == (3,4));
        }

        [Fact]
        public void ParseMultipleComplexStringToLine(){
            var line = @"1,1 -> 2,2
                        1,2 -> 3,4";
            var sut = new AdventOfCode2021.Day5(line);
            Assert.Contains<Line>(sut.Lines, l => l.Start == (1,1)&&l.End == (2,2));
            Assert.Contains<Line>(sut.Lines, l => l.Start == (1,2)&&l.End == (3,4));
        }
    }
}