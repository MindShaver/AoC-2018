using System;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new FileReader().ReadFile("input.txt");
            var checker = new IdChecker(input);


            Console.WriteLine($"Solution to Part One is {checker.SolvePartOne()}");
            Console.WriteLine($"Solution to Part Two is {checker.SolvePartTwo()}");
            Console.ReadKey();
        }
    }
}
