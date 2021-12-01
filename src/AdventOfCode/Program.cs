using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {   
            Work().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task Work(){
            var getInput = new GetInput();
            var input = await getInput.GetInputAsString(1);
            var day1 = new Day1(input);
            var res = day1.Part2();
            System.Console.WriteLine(res);
        } 
    }
}
