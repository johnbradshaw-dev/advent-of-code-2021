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
        public int Part1(){
            var greatestHorizontal = Inputs.Max();
            var costs = new List<int>();
            for (int i = 0; i < greatestHorizontal; i++)
            {
                costs.Add(Inputs.Select(input => Math.Abs(i - input)).Sum());
            }
            var bestPos = costs.IndexOf(costs.Min());
            Console.WriteLine($"The best position is {costs.IndexOf(costs.Min())} it costs {costs.Min()}");
            return costs.Min();
        }
        public long Part2(){
           var greatestHorizontal = Inputs.Max();
            var costs = new List<int>();
            for (int i = 0; i < greatestHorizontal; i++)
            {
                costs.Add(Inputs.Select(input => {
                    var n = Math.Abs(i - input);
                    return (n * (n + 1))/2;
                    }).Sum());
            }
            var bestPos = costs.IndexOf(costs.Min());
            Console.WriteLine($"The best position is {costs.IndexOf(costs.Min())} it costs {costs.Min()}");
            return costs.Min();
        }
    }
}