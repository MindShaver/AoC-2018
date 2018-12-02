using System.Collections.Generic;
using System.IO;

namespace DayOne
{
    public class FileReader
    {
        public IEnumerable<string> ReadLine(string filename)
        {
            using (var reader = new StreamReader(filename))
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
