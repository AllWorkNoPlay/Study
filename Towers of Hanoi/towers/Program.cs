using System;

namespace towers
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Number of discs? ");
            int i = int.Parse(Console.ReadLine());

            if (i > 0) State.NrOfDiscs = i;

            Console.WriteLine("[b]readth first or [d]epth first? ");
            char c = Char.Parse(Console.ReadLine().ToLower());




            var start = new State();
            var solver = new Solver();

            if (c=='d')
                {
                Console.WriteLine($"DEPTH FIRST, Towers of towers ,{State.NrOfDiscs} discs");
                Console.WriteLine($"    START - {DateTime.Now}");
                var solutionD = solver.SolveDepthFirst(start);
                Console.WriteLine($"    STOP  - {DateTime.Now}");

                Console.WriteLine("--- Solution ---");
                Console.WriteLine(solutionD.ToSolutionString());
                Console.ReadKey();
            }

            if(c=='b')
                {

                Console.WriteLine();

                Console.WriteLine($"BREADTH FIRST, Towers of towers ,{State.NrOfDiscs} discs");
                Console.WriteLine($"    START - {DateTime.Now}");
                var solutionB = solver.SolveBreadthFirst(start);
                Console.WriteLine($"    STOP  - {DateTime.Now}");

                Console.WriteLine("--- Solution ---");
                Console.WriteLine(solutionB.ToSolutionString());
                Console.ReadKey();
            }
        }
    }
}
