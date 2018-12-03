using System.Collections.Generic;
using System.IO;

namespace DayTwo
{
    public class FileReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while(null != (line = reader.ReadLine()))
                {
                    yield return line;
                }
            }
        }
    }
}