using System;

namespace DayThree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new FileReader().ReadFile("input.txt");
            var calculator = new ClaimCalculator(input);

            Console.WriteLine($"Solution to part one is {calculator.SolvePartOne()}");
            Console.WriteLine($"Solution to part two is {calculator.SolvePartTwo()}");
            Console.ReadKey();
        }
    }
}
