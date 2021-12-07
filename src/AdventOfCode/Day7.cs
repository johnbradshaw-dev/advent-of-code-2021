using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2021
{
    public class Day7
    {
        List<int> Inputs;
        public Day7(string input)
        {
            Inputs = input.Split(',').Select(i => int.Parse(i.Trim())).ToList();
        }
        
        private int _calculateCheapest(Func<int,int,int> costCalculation){
            var costs = new List<int>();
            for (int i = 0; i < Inputs.Max(); i++)
            {
                costs.Add(Inputs.Select(input => costCalculation(input,i)).Sum());
            }
            var bestPos = costs.IndexOf(costs.Min());
            Console.WriteLine($"The best position is {costs.IndexOf(costs.Min())} it costs {costs.Min()}");
            return costs.Min();
        }
        public int Part1() => _calculateCheapest((input, position) => Math.Abs(position - input));
        public long Part2() => _calculateCheapest((input, position) => {
                        var n = Math.Abs(position - input);
                        return (n * (n + 1))/2;
                    });
    }
}