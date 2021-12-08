using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2021
{
    public class Row{

        public List<int> Output = new List<int>();
        public Row(string line)
        {
            var input = line.Split('|').First().Trim().Split(' ');
            var output = line.Split('|').Last().Trim().Split(' ');
            var code = getCode(input);
            foreach (var number in output)
            {
                var result = code.FirstOrDefault(x => x.Value.Length == number.Length && x.Value.All(seg => number.Contains(seg)));
                if(result.Value != null)
                {
                    Output.Add(result.Key);
                }
                else
                {
                    throw new Exception($"number {number} does not appear in code");
                }
            }
        }

        private Dictionary<int, string> getCode(IEnumerable<string> input){
            var dict = new Dictionary<int, string>();
            dict.Add(1,input.First(i => i.Length == 2));
            dict.Add(7,input.First(i => i.Length == 3));
            dict.Add(4,input.First(i => i.Length == 4));
            dict.Add(8,input.First(i => i.Length == 7));
            dict.Add(9, input.First(i => i.Length == 6 && dict[4].All(i.Contains)));
            dict.Add(6, input.First(i => i.Length == 6 && !dict[4].All(i.Contains) 
                                                       && !dict[7].All(i.Contains)));
            dict.Add(0, input.First(i => i.Length == 6 && dict[6].Count(i.Contains) == 5 
                                                       && dict[9].Count(i.Contains) == 5 ));
            dict.Add(5, input.First(i => i.Length == 5 && dict[6].Count(i.Contains) == 5));
            dict.Add(3, input.First(i => i.Length == 5 && i.All(dict[9].Contains) && !i.All(dict[5].Contains)));
            dict.Add(2, input.First(i => i.Length == 5 && !dict[6].All(i.Contains) 
                                                       && !dict[9].All(i.Contains) 
                                                       && !i.All(dict[5].Contains) 
                                                       && !i.All(dict[3].Contains)));
            return dict;
        }
    }
    public class Day8
    {
        List<Row> Inputs;
        public Day8(string input)
        {
            Inputs = input.Trim().Split('\n').Select(i => i.Trim()).Select(i => new Row(i)).ToList();
        }
        
        public int Part1()=>Inputs.Sum(i=>i.Output.Count(o => (new int[]{1,4,7,8}).Contains(o)));
        public long Part2() => Inputs.Sum(i => {
            var stringNumber = string.Concat(i.Output.Select(o => o.ToString()));
            return long.Parse(stringNumber);
        });
    }
}