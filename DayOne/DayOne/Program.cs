using System;

namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new FileReader();
            var input = reader.ReadLine("input.txt");
            
            var frequency = new FrequencyTracker();

            Console.WriteLine($"Part One Solution - {frequency.SolveDayOne(input)}");
            Console.WriteLine($"Part Two Solution - {frequency.SolveDayTwo(input)}");
            Console.ReadKey();
        }
    }
}
