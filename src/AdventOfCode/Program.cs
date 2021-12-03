﻿using System.Threading.Tasks;

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
            var input = await getInput.GetInputAsString(3);
            var challenge = new Day3(input);
            var res = challenge.Part2();
            System.Console.WriteLine(res);
        } 
    }
}
