using System.Collections.Generic;

namespace DayThree
{
    public class ClaimCalculator
    {
        private IEnumerable<string> _input;
        private List<Claim> _claims = new List<Claim>();
        private int[][] _fabric = new int[2000][];
        private int _counter = 0;

        public ClaimCalculator(IEnumerable<string> input)
        {
            _input = input;
            Init();
        }

        private void Init()
        {
            for(var i = 0; i < 2000; i++)
            {
                _fabric[i] = new int[2000];
            }
        }

        public int SolvePartOne()
        {
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
                            _fabric[i][j] = 1;
                        }
                        else
                        {
                            _fabric[i][j] = 2;
                            _counter++;
                        }
                    }
                }
            }

            return _counter;
        }

        public int SolvePartTwo()
        {
            return 0;
        }

        private Claim CreateClaim(string claim)
        {
            var parsedId = claim.Split('@');
            var parsedDimensions = parsedId[1].Split(':');
            var lengthAndWidth = parsedDimensions[1].Split('x');
            var angles = parsedDimensions[0].Split(',');

            return new Claim
            {
                Id = parsedId[0].Substring(1),
                InchesFromLeft = int.Parse(angles[0]),
                InchesFromTop = int.Parse(angles[1]),
                Width = int.Parse(lengthAndWidth[0]),
                Height = int.Parse(lengthAndWidth[1])
            };
        }
    }
}
