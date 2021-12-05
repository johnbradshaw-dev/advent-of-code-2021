using Xunit;


namespace AdventOfCode.Tests.Day5
{
    public class Day5Part2Tests
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
            
            Assert.Equal(12, sut.Part2());
        }
    }
}
