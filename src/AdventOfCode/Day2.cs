using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day2
    {
        private string _input;
        private List<Tuple<string,int>> _instructions;
        public Day2(string input)
        {
            _input = input;
            _instructions = _input.Split('\n').Select(s => {
                    var parts = s.Trim().Split(' ');
                    var instruction = parts.First().Trim();
                    var amount = int.Parse(parts[1].Trim());
                    return new Tuple<string,int>(instruction, amount);
                }).ToList();
        }

        public int Part1(){
            var position = _instructions.Aggregate<Tuple<string,int>, Tuple<int,int>>(new Tuple<int,int>(0,0),(current, instruction)=>{
                switch (instruction.Item1)
                {
                    case "forward":
                        return new Tuple<int, int>(current.Item1 + instruction.Item2,current.Item2);
                    case "down":
                        return new Tuple<int, int>(current.Item1,current.Item2 + instruction.Item2);
                    case "up":
                        return new Tuple<int, int>(current.Item1,current.Item2 - instruction.Item2);
                    default:
                        return current;
                }
            });
            return position.Item1 * position.Item2;
        }

        public int Part2(){
            var position = _instructions.Aggregate<Tuple<string,int>, Tuple<int,int, int>>(new Tuple<int,int, int>(0,0, 0),(current, instruction)=>{
                switch (instruction.Item1)
                {
                    case "forward":
                        return new Tuple<int, int, int>(current.Item1 + instruction.Item2,current.Item2+instruction.Item2*current.Item3, current.Item3);
                    case "down":
                        return new Tuple<int, int, int>(current.Item1, current.Item2, current.Item3 + instruction.Item2);
                    case "up":
                        return new Tuple<int, int, int>(current.Item1, current.Item2, current.Item3 - instruction.Item2);
                    default:
                        return current;
                }
            });
            return position.Item1 * position.Item2;
        }
    }
}