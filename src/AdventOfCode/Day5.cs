using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Line
    {
        public Line((int x, int y) start, (int x, int y) end)
        {
            Start = start;
            End = end;
        }
        public (int x, int y) Start { get; set; }
        public (int x, int y) End { get; set; }
    }
    public class Day5
    {
        public List<Line> Lines = new List<Line>();
        public Day5(string input)
        {
            var stringLines = input.Split('\n').Select(l => l.Trim());
            var coords = stringLines.Select(l => l.Split(" -> ").ToList());
            Lines = coords.Select(c => {
                    var start = c.First().Split(',').Select(i => int.Parse(i));
                    var end = c.Last().Split(',').Select(i => int.Parse(i));
                    return new Line((start.First(), start.Last()),((end.First(),end.Last())));
                }).ToList();
        }

        public List<Line> FindHorizontalLines(){
            return Lines.Where(line => line.End.x == line.Start.x || line.End.y == line.Start.y).ToList();
        }


        public Dictionary<string, int> GetMarkedCoords(List<Line> lines){
            Dictionary<string,int> markedCoords = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                (int x, int y) diff = (line.End.x - line.Start.x, line.End.y - line.Start.y);
                (int x, int y) step = (diff.x != 0 ?diff.x/Math.Abs(diff.x) : 0,diff.y != 0? diff.y/Math.Abs(diff.y): 0);
                (int x, int y) currentPos = line.Start;
                do
                {
                    var key = $"{currentPos.x},{currentPos.y}";
                    if(!markedCoords.ContainsKey(key))
                    {
                        markedCoords[key] = 0;    
                    }
                    markedCoords[key] = markedCoords[key] + 1;
                    currentPos = (currentPos.x + step.x, currentPos.y + step.y);
                }while(!(currentPos.x == line.End.x + step.x && currentPos.y == line.End.y + step.y));
            }
            return markedCoords;
        }
        
        public int Part1(){
            var markedCoords = GetMarkedCoords(FindHorizontalLines());  
            var coordsWithMultiple = markedCoords.Where(v => v.Value > 1).ToList();
            return coordsWithMultiple.Count;

        }
        public int Part2(){
            var markedCoords = GetMarkedCoords(Lines);  
            var coordsWithMultiple = markedCoords.Where(v => v.Value > 1).ToList();
            return coordsWithMultiple.Count;
        }
    }
}