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
            var input = await getInput.GetInputAsString(2);
            var day2 = new Day2(input);
            var res = day2.Part2();
            System.Console.WriteLine(res);
        } 
    }
}
