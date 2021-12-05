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
        public int Part1(){
            Dictionary<string,int> markedCoords = new Dictionary<string, int>();
            
            foreach (var line in FindHorizontalLines())
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
                }while((currentPos.x != line.End.x || currentPos.y != line.End.y));
                
                var endkey = $"{currentPos.x},{currentPos.y}";
                if(!markedCoords.ContainsKey(endkey))
                {
                    markedCoords[endkey] = 0;    
                }
                markedCoords[endkey] = markedCoords[endkey] + 1;
            }
            var coordsWithMultiple = markedCoords.Where(v => v.Value > 1).ToList();
            return coordsWithMultiple.Count;

        }

        public int Part2(){
            Dictionary<string,int> markedCoords = new Dictionary<string, int>();
            
            foreach (var line in Lines)
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
                }while(!(currentPos.x == line.End.x && currentPos.y == line.End.y));
                var endkey = $"{currentPos.x},{currentPos.y}";
                if(!markedCoords.ContainsKey(endkey))
                {
                    markedCoords[endkey] = 0;    
                }
                markedCoords[endkey] = markedCoords[endkey] + 1;
            }
            var coordsWithMultiple = markedCoords.Where(v => v.Value > 1).ToList();
            return coordsWithMultiple.Count;
        }

        public bool DoLinesIntersect(Line lineA, Line lineB, out (int x, int y)? intersectPoint){
            float dx12 = lineA.End.x - lineA.Start.x;
            float dy12 = lineA.End.y - lineA.Start.y;
            float dx34 = lineB.End.x - lineB.Start.x;
            float dy34 = lineB.End.y - lineB.Start.y;

    // Solve for t1 and t2
    float denominator = (dy12 * dx34 - dx12 * dy34);

    float t1 =
        ((lineA.Start.x - lineB.Start.x) * dy34 + (lineB.Start.y - lineA.Start.y) * dx34)
            / denominator;
    if (float.IsInfinity(t1))
    {
        intersectPoint = null;
        return false;
    }

    float t2 =
        ((lineB.Start.x - lineA.Start.x) * dy12 + (lineA.Start.y - lineB.Start.y) * dx12)
            / -denominator;

    // Find the point of intersection.
    (float x, float y) exactIntersectPoint = (lineA.Start.x + dx12 * t1, lineA.Start.y + dy12 * t1);
    intersectPoint = ((int)exactIntersectPoint.x, (int)exactIntersectPoint.y);

    // The segments intersect if t1 and t2 are between 0 and 1.
    return
        ((t1 >= 0) && (t1 <= 1) &&
         (t2 >= 0) && (t2 <= 1));
        }
    }
}