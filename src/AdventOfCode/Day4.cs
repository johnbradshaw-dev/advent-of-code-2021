using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Bingo {
        public Bingo(List<int> numbers, List<Board> boards)
        {
            _numbers = numbers;
            _boards = boards;
        }
        private List<int> _numbers;

        private List<Board> _boards;

        public int LastCall;
        public Board PlayToFirstWin(){
            foreach (var number in _numbers)
            {
                LastCall = number;
                foreach (var board in _boards)
                {
                    if(board.Play(number))
                    {
                        return board;
                    }
                }
            }
            throw new Exception("nobody wins.");
        }

        public Board PlayToLastWin(){
            List<Board> wins = new List<Board>();
            List<Board> remainingBoards = _boards.ToList();
            foreach (var number in _numbers)
            {
                LastCall = number;
                wins = wins.Union(remainingBoards.Where(b => b.Play(number))).ToList();
                remainingBoards = remainingBoards.Where(b => !wins.Contains(b)).ToList();
            }
            return wins.Last();
        }
    }

    public class Board
    {
        public Board(string game)
        {
            var rows = game.Split('\n').Select(r => r.Trim());
            Rows = rows.Select(r => r.Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(n => int.Parse(n)).ToList()).ToList();
            Columns = new List<List<int>>();
            for (int i = 0; i < Rows.First().Count(); i++)
            {
                var column = new List<int>();
                for (int j = 0; j < Rows.Count(); j++)
                {
                    column.Add(Rows[j][i]);
                }
                Columns.Add(column);
            }
        }
        public List<List<int>> Rows;

        public List<List<int>> Columns;

        public List<int> MarkedNumbers = new List<int>();

        public bool Play(int number)
        {
            if(Rows.Any(r => r.Contains(number)))
            {
                MarkedNumbers.Add(number);
            }
            return Rows.Any(r => r.All(n => MarkedNumbers.Contains(n))) || Columns.Any(r => r.All(n => MarkedNumbers.Contains(n)));
        }
    }
    public class Day4
    {
        private Bingo _bingo;
        
        public Day4(string input)
        {
            var numbers = input.Split('\n').First().Split(',').Select(n => int.Parse(n.Trim())).ToList();
            var games = input.Split("\n\n").Skip(1).Select(g => new Board(g.Trim())).ToList();
            _bingo = new Bingo(numbers, games);
       }

        public int Part1(){
            var winner = _bingo.PlayToFirstWin();
            var nonMarkedNumbers = winner.Rows.SelectMany(x => x).ToList().Where(n => !winner.MarkedNumbers.Contains(n));
            return nonMarkedNumbers.Sum() * _bingo.LastCall;
        }

        public int Part2(){
            var winner = _bingo.PlayToLastWin();
            var nonMarkedNumbers = winner.Rows.SelectMany(x => x).ToList().Where(n => !winner.MarkedNumbers.Contains(n));
            return nonMarkedNumbers.Sum() * winner.MarkedNumbers.Last();
        }
    }
}