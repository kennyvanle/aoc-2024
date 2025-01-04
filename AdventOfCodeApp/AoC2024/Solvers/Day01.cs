using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 1: Historian Hysteria")]
public class Day01 : ISolver
{
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day01.txt");
        var solution = new Solution
        {
            Part1 = CalculateTotalDistance(input),
            Part2 = CalculateSimilarityScore(input)
        };

        return solution;
    }
    
    public static int CalculateTotalDistance(string input)
    {
        var lines = input.Split(["\r\n", "\n"], StringSplitOptions.None);
        List<int> left = [];
        List<int> right = [];
        foreach (var line in lines)
        {
            var arr = line.Split(" ");
            left.Add(int.Parse(arr[0]));
            right.Add(int.Parse(arr[^1]));
        }

        left.Sort();
        right.Sort();
        var total = 0;
        for (var i = 0; i < left.Count; i++)
        {
            total += Math.Abs(right[i] - left[i]);
        }

        return total;
    }

    public static int CalculateSimilarityScore(string input)
    {
        var lines = input.Split(["\r\n", "\n"], StringSplitOptions.None);
        List<int> left = [];
        List<int> right = [];
        foreach (var line in lines)
        {
            var arr = line.Split(" ");
            left.Add(int.Parse(arr[0]));
            right.Add(int.Parse(arr[^1]));
        }

        Dictionary<int, int> dupeCount = new();
        foreach (var val in right)
        {
            dupeCount[val] = dupeCount.GetValueOrDefault(val, 0) + 1;
        }

        return left.Sum(val => val * dupeCount.GetValueOrDefault(val, 0));
    }
}