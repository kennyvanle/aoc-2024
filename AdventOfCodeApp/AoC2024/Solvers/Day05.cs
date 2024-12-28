using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 5: Print Queue")]
public class Day05: ISolver
{
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day05.txt");
        var solution = new Solution
        {
            Part1 = SumValidInstructions(input),
            Part2 = SumFixedInstructions(input)
        };

        return solution;
    }
    public static int SumValidInstructions(string input)
    {
        var validInstructions = new List<string>();
        var parts = input.Split(["\n\n"], StringSplitOptions.None);
        var rulesInput = parts[0];
        var instructionsInput = parts[1];
        
        var rules = rulesInput.Split(["\n"], StringSplitOptions.None)
            .Select(line => Tuple.Create(int.Parse(line.Split('|')[0]), int.Parse(line.Split('|')[1])))
            .ToList();

        var instructions = instructionsInput.Split(["\n"], StringSplitOptions.None);
        foreach (var line in instructions)
        {
            var instruction = line.Split(',').Select(int.Parse).ToList();
            if (!IsOrderValid(instruction, rules)) continue;
            
            validInstructions.Add(line);
        }

        return validInstructions.Sum(instruction => int.Parse(instruction.Split(',')[instruction.Split(',').Length / 2]));
    }
    private static bool IsOrderValid(List<int> instruction, List<Tuple<int, int>> rules)
    {
        foreach (var (pageA, pageB) in rules)
        {
            if (!instruction.Contains(pageA) || !instruction.Contains(pageB)) continue;
            
            var indexA = instruction.IndexOf(pageA);
            var indexB = instruction.IndexOf(pageB);
            if (indexB < indexA) return false;
        }
        
        return true;
    }

    public static int SumFixedInstructions(string input)
    {
        var invalidInstructions = new List<string>();
        var parts = input.Split(["\n\n"], StringSplitOptions.None);
        var rulesInput = parts[0];
        var instructionsInput = parts[1];
        
        var rules = rulesInput.Split(["\n"], StringSplitOptions.None)
            .Select(line => Tuple.Create(int.Parse(line.Split('|')[0]), int.Parse(line.Split('|')[1])))
            .ToList();

        var instructions = instructionsInput.Split(["\n"], StringSplitOptions.None);
        foreach (var line in instructions)
        {
            var instruction = line.Split(',').Select(int.Parse).ToList();
            if (IsOrderValid(instruction, rules)) continue;
            
            invalidInstructions.Add(line);
        }

        var validInstructions = new List<List<int>>();

        foreach (var line in invalidInstructions)
        {
            var instruction = line.Split(',').Select(int.Parse).ToList();
            var sorted = Sort(instruction, rules);
            validInstructions.Add(sorted);
        }

        return validInstructions.Sum(instruction => instruction[instruction.Count / 2]);
    }

    private static List<int> Sort(List<int> instructions, List<Tuple<int, int>> rules)
    {
        var i = 0;
        while (i != instructions.Count)
        {
            i = instructions.Count;
            foreach (var (pageA, pageB) in rules)
            {
                if(!instructions.Contains(pageA) || !instructions.Contains(pageB)) continue;
                
                var indexA = instructions.IndexOf(pageA);
                var indexB = instructions.IndexOf(pageB);
                if (indexA <= indexB) continue;
                
                i--;
                instructions.RemoveAt(indexA);
                instructions.Insert(indexB, pageA);
            }
        }

        return instructions;
    }
}