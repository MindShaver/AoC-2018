using System.Collections.Generic;

namespace DayOne
{
    public class FrequencyTracker
    {
        private int _currentFrequency = 0;
        private HashSet<int> _frequencySet = new HashSet<int>();

        public int SolveDayOne(IEnumerable<string> input)
        {
            foreach(var line in input)
            {
                ExecuteCommand(line);
            }

            return _currentFrequency;
        }

        public int SolveDayTwo(IEnumerable<string> input)
        {
            _currentFrequency = 0;
            var duplicateFrequency = RunList(input);

            while(!duplicateFrequency.Found)
            {
                duplicateFrequency = RunList(input);
            }

            return duplicateFrequency.Result;
        }

        private DuplicateChecker RunList(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                ExecuteCommand(line);

                if (_frequencySet.Contains(_currentFrequency))
                {
                    return new DuplicateChecker
                    {
                        Result = _currentFrequency,
                        Found = true
                    };
                }

                _frequencySet.Add(_currentFrequency);
            }

            return new DuplicateChecker {
                Found = false
            };
        }

        private void ExecuteCommand(string command)
        {
            var direction = command[0];
            var amount = int.Parse(command.Substring(1));

            ChangeFrequency(direction, amount);
        }

        private void ChangeFrequency(char direction, int amount)
        {
            if (direction == '+')
                _currentFrequency += amount;
            else
                _currentFrequency -= amount;
        }
    }

    struct DuplicateChecker
    {
        public bool Found;
        public int Result;
    }
}