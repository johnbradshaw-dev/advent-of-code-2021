using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day6
    {
        public List<int> Fish;
        public Day6(string input)
        {
            Fish = input.Split(',').Select(s => int.Parse(s.Trim())).ToList();
        }
        public int Part1(int days = 80){
            var fishes = Fish.ToList();
            
            for (int i = 0; i < days; i++)
            {
                var newFish = new List<int>();
                fishes = fishes.Select(f => {
                    var updatedFish = f-1;
                    if(updatedFish < 0)
                    {
                        newFish.Add(8);
                        updatedFish = 6;
                    }
                    return updatedFish;
                }).ToList();
                fishes.AddRange(newFish);
            }
            return fishes.Count();
        }
        public long Part2(int days = 256){
            
            var fishDict = new Dictionary<int,long>();
            foreach (var fish in Fish)
            {
                if(!fishDict.ContainsKey(fish))
                {
                    fishDict[fish] = 0;
                }
                fishDict[fish]=fishDict[fish] + 1;
            }

            for (int i = 0; i < days; i++)
            {
                var zeros = fishDict.ContainsKey(0)?fishDict[0]:0;
                
                fishDict = fishDict.Select(fd => new KeyValuePair<int,long>(fd.Key -1, fd.Value)).ToDictionary(fd => fd.Key, fishDict=> fishDict.Value);
                
                fishDict[6] = (fishDict.ContainsKey(6)? fishDict[6] : 0) + zeros;
                fishDict[8] = zeros;
                fishDict.Remove(-1);
            }
            return fishDict.Sum(f => f.Value);
        }
    }
}