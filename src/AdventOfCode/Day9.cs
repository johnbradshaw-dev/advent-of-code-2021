using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2021
{
    
    public class Day9
    {
        List<string> Inputs;

        public Day9(string input)
        {
            Inputs = input.Trim().Split('\n').Select(r => r.Trim()).ToList();
        }
        
        public int Part1(){
            var height = Inputs.Count();
            var width = Inputs.First().Length;
            var lowPoints = new List<int>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var current = int.Parse(Inputs[y][x].ToString());
                    var adjacent = new List<int>{
                        y>0 ? int.Parse(Inputs[y-1][x].ToString()):99,
                        y<height-1 ? int.Parse(Inputs[y+1][x].ToString()):99,
                        x>0 ? int.Parse(Inputs[y][x-1].ToString()):99,
                        x<width-1 ? int.Parse(Inputs[y][x+1].ToString()): 99
                    };
                    if(current<adjacent.Min())
                    {
                        lowPoints.Add(current);
                    }
                }
            }
            return lowPoints.Sum(n => 1+n);
        }
        public long Part2() =>0;
    }
}