using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {   
           var getInput = new GetInput();
            var input = getInput.GetInputAsString(9);
            var challenge = new Day9(input);
            var res = challenge.Part1();
            System.Console.WriteLine(res);
        }

    }
}
