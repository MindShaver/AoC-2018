using System;
using System.Collections.Generic;
using System.Linq;

namespace DayThree
{
    public class ClaimCalculator
    {
        private IEnumerable<string> _input;
        private List<Claim> _claims = new List<Claim>();
        private int[][] _fabric;
        private int _counter = 0;

        public ClaimCalculator(IEnumerable<string> input)
        {
            _input = input;
        }

        private void Init()
        {
            _fabric = new int[2000][];
            for(var i = 0; i < 2000; i++)
            {
                _fabric[i] = new int[2000];
            }
        }

        public int SolvePartOne()
        {
            Init();
            foreach(var claim in _input)
            {
                _claims.Add(CreateClaim(claim));
            }

            foreach(var c in _claims)
            {
                for (var i = c.InchesFromTop; i < c.Height + c.InchesFromTop; i++)
                {
                    for (var j = c.InchesFromLeft; j < c.Width+ c.InchesFromLeft; j++)
                    {
                        if(_fabric[i][j] == 0)
                        {
                            _fabric[i][j] = int.Parse(c.Id);
                        }
                        else
                        {
                            _fabric[i][j] = -1;
                        }
                    }
                }
            }

            for (var i = 0; i < _fabric.Length; i++)
            {
                for (var j = 0; j < _fabric[i].Length; j++)
                {
                    if (_fabric[i][j] == -1)
                    {
                        _counter++;
                    }
                }
            }

            return _counter;
        }

        public string SolvePartTwo()
        {
            Init();
            _claims = new List<Claim>();

            foreach (var claim in _input)
            {
                _claims.Add(CreateClaim(claim));
            }

            foreach (var c in _claims)
            {
                for (var i = c.InchesFromTop; i < c.Height + c.InchesFromTop; i++)
                {
                    for (var j = c.InchesFromLeft; j < c.Width + c.InchesFromLeft; j++)
                    {
                        if (_fabric[i][j] == 0)
                        {
                            _fabric[i][j] = int.Parse(c.Id);
                        }
                        else
                        {
                            if (_fabric[i][j] != -1)
                            {
                                var id = _fabric[i][j].ToString();
                                _claims.First(x => x.Id == id).NoOverlap = false;
                                _fabric[i][j] = -1;
                            }

                            c.NoOverlap = false;
                        }
                    }
                }
            }

            return _claims.First(x => x.NoOverlap).Id;
        }

        private Claim CreateClaim(string claim)
        {
            var parsedId = claim.Split('@');
            var parsedDimensions = parsedId[1].Split(':');
            var lengthAndWidth = parsedDimensions[1].Split('x');
            var angels = parsedDimensions[0].Split(',');

            return new Claim
            {
                Id = parsedId[0].Substring(1).Trim(),
                InchesFromLeft = int.Parse(angels[0]),
                InchesFromTop = int.Parse(angels[1]),
                Width = int.Parse(lengthAndWidth[0]),
                Height = int.Parse(lengthAndWidth[1]),
                NoOverlap = true
            };
        }
    }
}
