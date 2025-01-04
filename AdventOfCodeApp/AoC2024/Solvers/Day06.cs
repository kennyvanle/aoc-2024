using Common;

namespace AoC2024.Solvers;

[ProblemDescription("2024 Day 6: Guard Gallivant")]
public class Day06 : ISolver
{
    private const char Obstacle = '#';
    private const char Start = '^';
    private static HashSet<(int, int)> _pathTaken = [];
    public Solution Solve()
    {
        var input = FileReader.ReadFileContent("Day06.txt");
        var solution = new Solution
        {
            Part1 = DetermineDistinctPositions(input),
            Part2 = DetermineDistinctObstructions(input)
        };

        return solution;
    }

    public static int DetermineDistinctPositions(string input)
    {
        var grid = input.Split(["\r\n", "\n"], StringSplitOptions.None).Select(row => row.ToCharArray()).ToArray();
        
        var rows = grid.Length; 
        var cols = grid[0].Length;
        
        for (var i = 0; i < rows; i++){
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] != Start) continue;
                Move(grid, i, j, Start, _pathTaken);
            }
        }
        return _pathTaken.Count;
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
    
    public static int DetermineDistinctObstructions(string input)
    {
        DetermineDistinctPositions(input);

        var grid = input.Split(["\r\n", "\n"], StringSplitOptions.None).Select(row => row.ToCharArray()).ToArray();

        var rows = grid.Length; 
        var cols = grid[0].Length;

        var guardCoordinate = GetGuardStartingPosition(grid);

        var result = 0;
        for (var i = 0; i < rows; i++){
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == Start || grid[i][j] == Obstacle) continue;
                if (!_pathTaken.Contains((i, j))) continue;
                var positions = new HashSet<(int, int, char)>();
                grid[i][j] = Obstacle;
                if (HasLoop(grid, guardCoordinate[0], guardCoordinate[1], Start, positions))
                {
                    result++;
                }

                grid[i][j] = '.';
            }
        }
        return result;
    }

    private static int[] GetGuardStartingPosition(char[][] grid)
    {
        for (var i = 0; i < grid.Length; i++){
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] != Start) continue;
                return [i, j];
            }
        }

        throw new ArgumentException("Invalid guard starting position");
    }

    private static bool HasLoop(char[][] grid, int row, int col, char dir, HashSet<(int, int, char)> positions)
    {
        while (true)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
            {
                return false;
            }

            if (positions.Contains((row, col, dir)))
            {
                return true;
            }
            
            if (grid[row][col] == Obstacle)
            {
                var moveBack = MoveBack(dir);
                row += moveBack[0];
                col += moveBack[1];
                dir = Turn(dir);
                continue;
            }

            positions.Add((row, col, dir));
            
            var moveDirection = GetMoveDirection(dir);

            row += moveDirection[0];
            col += moveDirection[1];
        }
    }
}