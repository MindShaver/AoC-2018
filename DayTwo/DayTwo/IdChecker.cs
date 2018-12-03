using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTwo
{
    public class IdChecker
    {
        private IEnumerable<string> _ids;

        public IdChecker(IEnumerable<string> input)
        {
            _ids = input;
        }

        public int SolvePartOne()
        {
            var duplicateCount = 0;
            var triplicateCount = 0;

            foreach(var id in _ids)
            {
                if(CheckForDuplicate(id))
                {
                    duplicateCount++;
                }

                if(CheckForTriplicate(id))
                {
                    triplicateCount++;
                }
            }

            return duplicateCount * triplicateCount;
        }

        public string SolvePartTwo()
        {
            var commonStrings = FindCommonLetters();
            var builtString = BuildMatchingString(commonStrings);

            return builtString;
        }

        private string BuildMatchingString(IEnumerable<string> commonStrings)
        {
            var stringArray = commonStrings.ToArray();
            var string1 = stringArray[0];
            var string2 = stringArray[1];
            var sb = new StringBuilder();

            for(var i = 0; i < string1.Length; i++)
            {
                if(string1[i] == string2[i])
                {
                    sb.Append(string1[i]);
                }
            }

            return sb.ToString();
        }

        private List<string> FindCommonLetters()
        {
            var temp = new List<string>();
            foreach(var id in _ids)
            {
                var compare = _ids.Where(x => x.HasOneDiff(id) == true);

                if (compare.Count() > 0)
                {
                    temp.AddRange(compare);
                };
            }
        
            return temp;
        }

        private bool CheckForDuplicate(string id)
        {
            var duplicates = id.GroupBy(x => x).Where(x => x.Count() == 2).Count();

            return duplicates > 0;
        }

        private bool CheckForTriplicate(string id)
        {
            var triplicates = id.GroupBy(x => x).Where(x => x.Count() == 3).Count();

            return triplicates > 0;
        }
    }
}
