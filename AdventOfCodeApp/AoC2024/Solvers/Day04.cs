using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 4: Ceres Search")]
public partial class Day04 : ISolver
{
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day04.txt");
        var solution = new Solution
        {
            Part1 = FindAllXmas(input),
            Part2 = FindAllXmasPart2(input)
        };

        return solution;
    }

    public static int FindAllXmas(string input)
    {
        var grid = input.Split("\n").Select(row => row.ToCharArray()).ToArray();
        
        var rows = grid.Length; 
        var cols = grid[0].Length;
        
        var total = 0;
        
        for (var i = 0; i < rows; i++){
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] != 'X') continue;
                var res = FindXmas(grid, i, j);
                total += res;
            }
        }
        
        return total;
    }
    
    private static int FindXmas(char[][] grid, int x, int y)
    {
        const string target = "XMAS";
        int[][] directions =
        [
            [1, 0],
            [-1, 0],
            [0, 1],
            [0, -1],
            [1, 1],
            [1, -1],
            [-1, 1],
            [-1, -1]
        ];

        return directions.Count(dir =>
            TryGetLetter(grid, x + dir[0], y + dir[1], out var letter2) &&
            TryGetLetter(grid, x + 2 * dir[0], y + 2 * dir[1], out var letter3) &&
            TryGetLetter(grid, x + 3 * dir[0], y + 3 * dir[1], out var letter4) &&
            $"X{letter2}{letter3}{letter4}" == target);
    }

    private static bool TryGetLetter(char[][] grid, int x, int y, out char letter)
    {
        letter = '\0';
        if (x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length)
        {
            letter = grid[x][y];
            return true;
        }
        return false;
    }
    
    public static int FindAllXmasPart2(string input)
    {
        var grid = input.Split("\n").Select(row => row.ToCharArray()).ToArray();
        
        var rows = grid.Length; 
        var cols = grid[0].Length;
        
        var total = 0;
        
        for (var i = 0; i < rows; i++){
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] != 'A') continue;
                var res = FindXmasPart2(grid, i, j);
                total += res;
            }
        }
        
        return total;
    }
    
    private static int FindXmasPart2(char[][] grid, int x, int y)
    {
        var targets = new[] { "MS", "SM" };

        if (TryGetLetter(grid, x + 1, y + 1, out var bottomRight) &&
            TryGetLetter(grid, x - 1, y - 1, out var topLeft) &&
            TryGetLetter(grid, x + 1, y - 1, out var topRight) &&
            TryGetLetter(grid, x - 1, y + 1, out var bottomLeft))
        {
            var diagonal1 = new string(new[] { bottomLeft, topRight });
            var diagonal2 = new string(new[] { topLeft, bottomRight });

            if (targets.Contains(diagonal1) && targets.Contains(diagonal2))
            {
                return 1;
            }
        }

        return 0;
    }
}