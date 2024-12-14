using System.Diagnostics;

namespace Common;

public class CompositeSolver(IEnumerable<ISolver> solvers)
{
    private readonly IEnumerable<ISolver> _solvers = solvers ?? throw new ArgumentNullException(nameof(solvers));

    public void Solve()
    {
        foreach (var solver in _solvers)
        {
            var problemDescription = Attribute.GetCustomAttribute(solver.GetType(), typeof(ProblemDescription)) as ProblemDescription;
            Console.WriteLine(problemDescription?.Name);
            
            Stopwatch stopwatch = new();
            stopwatch.Start();
            
            var solution = solver.Solve();
            
            stopwatch.Stop();
            var elapsedTime = stopwatch.Elapsed;
            
            Console.WriteLine($"Execution time: {elapsedTime}");
            Console.WriteLine("Part 1: " + solution.Part1);
            if (solution.Part2 != null)
            {
                Console.WriteLine("Part 2: " + solution.Part2);
            }

            Console.WriteLine();
        }
    }
}