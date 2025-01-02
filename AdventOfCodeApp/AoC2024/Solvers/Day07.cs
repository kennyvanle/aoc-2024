using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 7: Bridge Repaid")]
public class Day07 : ISolver
{
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day07.txt");
        var solution = new Solution
        {
            Part1 = DetermineCalibration(input),
            Part2 = DetermineCalibrationWithConcatenation(input)
        };

        return solution;
    }

    public static long DetermineCalibration(string input)
    {
        var lines = input.Split("\n");

        var result = 0l;
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var goal = long.Parse(parts[0]);
            var nums = parts[1].Split(" ").Select(long.Parse).ToArray();;

            if (IsValid(goal, nums))
            {
                result += goal;
            }
        }

        return result;
    }
    
    private static bool IsValid(long goal, long[] operands)
    {
        var memo = new Dictionary<(long accumulatedVal, long index), bool>();

        return DynamicProgrammingCalibration(operands[0], 1);
        
        bool DynamicProgrammingCalibration(long accumulatedVal, long index)
        {
            if (memo.ContainsKey((accumulatedVal, index)))
                return memo[(accumulatedVal, index)];

            if (accumulatedVal == goal && index == operands.Length)
                return true;

            if (accumulatedVal > goal || index == operands.Length)
                return false;

            var result = DynamicProgrammingCalibration(accumulatedVal + operands[index], index + 1) ||
                         DynamicProgrammingCalibration(accumulatedVal * operands[index], index + 1);

            memo[(accumulatedVal, index)] = result;

            return result;
        }
    }

    public static object DetermineCalibrationWithConcatenation(string input)
    {
        var lines = input.Split("\n");

        var result = 0l;
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var goal = long.Parse(parts[0]);
            var nums = parts[1].Split(" ").Select(long.Parse).ToArray();;

            if (IsValidWithConcatenation(goal, nums))
            {
                result += goal;
            }
        }

        return result;
    }

    private static bool IsValidWithConcatenation(long goal, long[] operands)
    {
        var memo = new Dictionary<(long accumulatedVal, long index), bool>();

        return DynamicProgrammingCalibration(operands[0], 1);
        
        bool DynamicProgrammingCalibration(long accumulatedVal, long index)
        {
            if (memo.ContainsKey((accumulatedVal, index)))
                return memo[(accumulatedVal, index)];

            if (accumulatedVal == goal && index == operands.Length)
                return true;

            if (accumulatedVal > goal || index == operands.Length)
                return false;

            var result = DynamicProgrammingCalibration(accumulatedVal + operands[index], index + 1) ||
                         DynamicProgrammingCalibration(accumulatedVal * operands[index], index + 1) ||
                         DynamicProgrammingCalibration(long.Parse(accumulatedVal + operands[index].ToString()), index + 1);

            memo[(accumulatedVal, index)] = result;

            return result;
        }
    }
}