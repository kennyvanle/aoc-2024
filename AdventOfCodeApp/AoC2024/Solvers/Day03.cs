using System.Text.RegularExpressions;

using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 3: Mull it Over")]
public partial class Day03 : ISolver
{
    private const string Pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
    
    private const string DoPattern = @"do\(\)";
    private const string DontPattern = @"don\'t\(\)";
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day03.txt");
        var solution = new Solution
        {
            Part1 = CalculateSumOfProducts(input),
            Part2 = CalculateSumOfProductsWhenEnabled(input)
        };

        return solution;
    }

    public static int CalculateSumOfProducts(string input)
    {
        var matches = MultiplyRegex().Matches(input);
        var sum = 0;
        foreach (Match match in matches)
        {
            var val1 = int.Parse(match.Groups[1].Value);
            var val2 = int.Parse(match.Groups[2].Value);
            sum += val1 * val2;
        }
        return sum;
    }

    [GeneratedRegex(Pattern, RegexOptions.Compiled)]
    private static partial Regex MultiplyRegex();
    
    [GeneratedRegex(DoPattern, RegexOptions.Compiled)]
    private static partial Regex DoRegex();
    
    [GeneratedRegex(DontPattern, RegexOptions.Compiled)]
    private static partial Regex DontRegex();

    public static int CalculateSumOfProductsWhenEnabled(string input)
    {
        var doMatches = DoRegex().Matches(input);
        var dontMatches = DontRegex().Matches(input);
        var multMatches = MultiplyRegex().Matches(input);
        
        var sum = 0;

        foreach (Match multMatch in multMatches)
        {
            var multIndex = multMatch.Index;

            var shouldMultiply = true;
            for (var i = multIndex - 1; i >= 0; i--)
            {
                if (doMatches.Any(x => x.Index == i))
                {
                    shouldMultiply = true;
                    break;
                }

                if (dontMatches.Any(x => x.Index == i))
                {
                    shouldMultiply = false;
                    break;
                }
            }

            if (!shouldMultiply) continue;
            
            var val1 = int.Parse(multMatch.Groups[1].Value);
            var val2 = int.Parse(multMatch.Groups[2].Value);
            sum += val1 * val2;
        }

        return sum;
    }
}