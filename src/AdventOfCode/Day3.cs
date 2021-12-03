using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day3
    {
        private string _input;
        private List<string> _binaries;

        private int[] _counts;

        private int _length;
        public Day3(string input)
        {
            _input = input;
            _binaries = input.Split("\n").Select(x => x.Trim()).ToList();
            _length = _binaries.First().Length;
            _counts = new int[_length];

        }

        public int Part1(){
            
            foreach (var binary in _binaries)
            {
                for (int i = 0; i < binary.Length; i++)
                {
                    if(int.Parse(binary[i].ToString())>0)
                    {
                        _counts[i] = _counts[i] + 1;
                    }
                }
            }

            string gammaBinary = "";
            string epsilonBinary = "";

            for (int i = 0; i < _length; i++)
                {
                    if(_counts[i] > _binaries.Count()/2)
                    {
                        gammaBinary += "1";
                        epsilonBinary += "0";
                    }
                    else
                    {
                        gammaBinary += "0";
                        epsilonBinary += "1";
                    }
                }

            var gamma = Convert.ToInt32(gammaBinary,2);
            var epsilon = Convert.ToInt32(epsilonBinary,2);


            return gamma*epsilon;
        }

        public int Part2(){
            var ogList = _binaries.ToList();
            var scrubList = _binaries.ToList();
            var counts = new int[_length];
            Console.WriteLine(ogList.Count());
            var mostCommonFirstBit = 1;
            for (int i = 0; i < _length; i++)
            {
                foreach (var binary in ogList)
                {
                    if(int.Parse(binary[i].ToString())>0)
                    {
                        counts[i] = counts[i] + 1;
                    }
                }
                decimal half = Convert.ToDecimal(ogList.Count())/2;
                mostCommonFirstBit = counts[i] >= half ? 1 : 0;
                Console.WriteLine(mostCommonFirstBit);
                ogList = ogList.Where(b => b[i].ToString() == mostCommonFirstBit.ToString()).ToList();
                if(ogList.Count() == 1)
                {
                    break;
                }
            }

            counts = new int[_length];
            var leastCommonFirstBit = 0;
            for (int i = 0; i < _length; i++)
            {
                foreach (var binary in scrubList)
                {
                    if(int.Parse(binary[i].ToString())>0)
                    {
                        counts[i] = counts[i] + 1;
                    }
                }
                decimal half = Convert.ToDecimal(scrubList.Count())/2;
                leastCommonFirstBit = counts[i] >= half ? 0 : 1;
                scrubList = scrubList.Where(b => b[i].ToString() == leastCommonFirstBit.ToString()).ToList();
                if(scrubList.Count() == 1)
                {
                    break;
                }
            }
            System.Console.WriteLine($"{ogList.Single()} = {Convert.ToInt32(ogList.Single(),2)}");
            System.Console.WriteLine($"{scrubList.Single()} = {Convert.ToInt32(scrubList.Single(),2)}");
            

            return Convert.ToInt32(ogList.Single(),2) * Convert.ToInt32(scrubList.Single(),2);
        }
    }
}