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
            var input = await getInput.GetInputAsString(5);
            var challenge = new Day5(input);
            var res = challenge.Part2();
            System.Console.WriteLine(res);
        } 
    }
}
