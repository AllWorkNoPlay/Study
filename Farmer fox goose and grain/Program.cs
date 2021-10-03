using System;

namespace goose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Farmer, wolf, goose, grain problem\n");

            Console.WriteLine("[b]readth first or [d]epth first? ");
            char c = Char.Parse(Console.ReadLine().ToLower());

            var solver = new Solver();

            if (c == 'd')
            {
                Console.WriteLine($"DEPTH FIRST");
                Console.WriteLine($"    START - {DateTime.Now}");
                var solutionD = solver.SolveDepthFirst(Solver.start);
                Console.WriteLine($"    STOP  - {DateTime.Now}");

                Console.WriteLine(solutionD.ToSolutionString());
                Console.ReadKey();
            }

            if (c == 'b')
            {

                Console.WriteLine();

                Console.WriteLine($"BREADTH FIRST");
                Console.WriteLine($"    START - {DateTime.Now}");
                var solutionB = solver.SolveBreadthFirst(Solver.start);
                Console.WriteLine($"    STOP  - {DateTime.Now}");

                Console.WriteLine(solutionB.ToSolutionString());
                Console.ReadKey();
            }
        }
    }
}
