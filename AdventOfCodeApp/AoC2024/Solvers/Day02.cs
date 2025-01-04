using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 2: Red-Nosed Reports")]
public class Day02 : ISolver
{
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day02.txt");
        var solution = new Solution
        {
            Part1 = CalculateSafeReports(input),
            Part2 = CalculateSafeReports(input, true)
        };

        return solution;
    }

    public static int CalculateSafeReports(string input, bool withTolerance = false)
    {
        var rows = input.Split(["\r\n", "\n"], StringSplitOptions.None);
        var safeCount = 0;

        foreach (var row in rows)
        {
            var arr = row.Split(" ");
            var levels = Array.ConvertAll(arr, int.Parse).ToList();

            if (withTolerance)
            {
                if (levels.Where((_, i) => IsSafe(SkipIndex(levels, i).ToList())).Any())
                {
                    safeCount++;
                }
            }
            else
            {
                if (IsSafe(levels))
                {
                    safeCount++;
                }
            }
        }

        return safeCount;
    }

    private static bool IsSafe(List<int> levels)
    {
        var isSafe = true;
        for (var i = 0; i < levels.Count - 1; i++)
        {
            if (!CheckBuffer(levels[i], levels[i + 1]))
            {
                isSafe = false;
                break;
            }

            if (CheckArrayOrder(levels)) continue;
            isSafe = false;
            break;
        }

        return isSafe;
    }

    private static bool CheckArrayOrder(List<int> levels)
    {
        return levels.SequenceEqual(levels.OrderBy(x => x)) ||
               levels.SequenceEqual(levels.OrderByDescending(x => x));
    }
    
    private static bool CheckBuffer(int a, int b)
    {
        var diff = Math.Abs(b - a);
        return diff is >= 1 and <= 3;
    }
    
    private static IEnumerable<int> SkipIndex(List<int> levels, int i) => levels.Where((_, j) => j != i);
}