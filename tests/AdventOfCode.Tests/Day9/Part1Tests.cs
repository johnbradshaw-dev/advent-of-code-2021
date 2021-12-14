using Xunit;

namespace AdventOfCode.Tests.Day9
{
    public class Part1Tests
    {
        [Fact]
        public void ExampleData()
        {
            string testData = @"2199943210
                                3987894921
                                9856789892
                                8767896789
                                9899965678";
            var sut = new AdventOfCode2021.Day9(testData);

            Assert.Equal(15, sut.Part1());
        }
    }
}