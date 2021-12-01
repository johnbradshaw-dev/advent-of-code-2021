using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day1
    {
        private string _input;
        public Day1(string input)
        {
            _input = input;
        }

        public int Part1(){
            int count = 0;
            var list = _input.Split("\n");
            for (int i = 1; i < list.Length; i++)
            {
                if(int.Parse(list[i])>int.Parse(list[i-1])){
                    count ++;
                }
            }
            return count;
        }

        public int Part2(){
            int count = 0;
            var list = _input.Split("\n");
            List<int> sums = new List<int>();
            for (int i = 2; i < list.Length; i++)
            {
                sums.Add(int.Parse(list[i]) + int.Parse(list[i-1]) + int.Parse(list[i-2]));
            }
            for (int i = 1; i < sums.Count; i++)
            {
                if(sums[i] > sums[i-1])
                {
                    count ++;
                }
            }
            return count;
        }
    }
}