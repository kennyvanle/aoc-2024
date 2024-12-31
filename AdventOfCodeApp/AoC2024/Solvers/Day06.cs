using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 6: Guard Gallivant")]
public class Day06 : ISolver
{
    private const char Obstacle = '#';
    private const char Start = '^';
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day06.txt");
        var solution = new Solution
        {
            Part1 = DetermineDistinctPositions(input),
        };

        return solution;
    }

    public static int DetermineDistinctPositions(string input)
    {
        var grid = input.Split("\n").Select(row => row.ToCharArray()).ToArray();
        
        var rows = grid.Length; 
        var cols = grid[0].Length;
        
        var positions = new HashSet<(int, int)>();
        
        for (var i = 0; i < rows; i++){
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] != Start) continue;
                Move(grid, i, j, Start, positions);
            }
        }
        return positions.Count;
    }

    private static void Move(char[][] grid, int row, int col, char dir, HashSet<(int, int)> positions)
    {
        while (true)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
            {
                return;
            }
            
            if (grid[row][col] == Obstacle)
            {
                var moveBack = MoveBack(dir);
                row += moveBack[0];
                col += moveBack[1];
                dir = Turn(dir);
                continue;
            }

            positions.Add((row, col));
            
            var moveDirection = GetMoveDirection(dir);

            row += moveDirection[0];
            col += moveDirection[1];
        }
    }

    private static int[] MoveBack(char dir)
    {
        return dir switch
        {
            '^' => [1, 0],
            '>' => [0, -1],
            'v' => [-1, 0],
            '<' => [0, 1],
            _ => throw new ArgumentException("invalid move direction")
        };
    }

    private static int[] GetMoveDirection(char dir)
    {
        return dir switch
        {
            '^' => [-1, 0],
            '>' => [0, 1],
            'v' => [1, 0],
            '<' => [0, -1],
            _ => throw new ArgumentException("invalid move direction")
        };
    }

    private static char Turn(char dir)
    {
        return dir switch
        {
            '^' => '>',
            '>' => 'v',
            'v' => '<',
            '<' => '^',
            _ => throw new ArgumentException("invalid turn direction")
        };
    }
}