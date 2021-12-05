using System;
using Xunit;
using AdventOfCode2021;

namespace AdventOfCode.Tests.Day5
{
    public class Day5Part1Tests
    {
        [Fact]
        public void ExampleData()
        {
            var exampleData = @"0,9 -> 5,9
            8,0 -> 0,8
            9,4 -> 3,4
            2,2 -> 2,1
            7,0 -> 7,4
            6,4 -> 2,0
            0,9 -> 2,9
            3,4 -> 1,4
            0,0 -> 8,8
            5,5 -> 8,2";
            var sut = new AdventOfCode2021.Day5(exampleData);
            
            Assert.Equal(5,sut.Part1());
        }

        [Fact]
        public void FindHorizontalAndVertical()
        {
            var exampleData = @"0,9 -> 5,9
            8,0 -> 0,8
            9,4 -> 3,4
            2,2 -> 2,1
            7,0 -> 7,4
            6,4 -> 2,0
            0,9 -> 2,9
            3,4 -> 1,4
            0,0 -> 8,8
            5,5 -> 8,2";
            var sut = new AdventOfCode2021.Day5(exampleData);
            Assert.Equal(10,sut.Lines.Count);
            var lines = sut.FindHorizontalLines();
            Assert.Equal(6, lines.Count);
            Assert.Contains<Line>(lines, l => l.Start == (0,9)&&l.End == (5,9));
            Assert.Contains<Line>(lines, l => l.Start == (9,4)&&l.End == (3,4));
            Assert.Contains<Line>(lines, l => l.Start == (2,2)&&l.End == (2,1));
            Assert.Contains<Line>(lines, l => l.Start == (7,0)&&l.End == (7,4));
            Assert.Contains<Line>(lines, l => l.Start == (0,9)&&l.End == (2,9));
            Assert.Contains<Line>(lines, l => l.Start == (3,4)&&l.End == (1,4));
        }
    }
}
