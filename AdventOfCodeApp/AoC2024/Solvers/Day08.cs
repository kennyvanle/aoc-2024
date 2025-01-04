using Common;

namespace AoC2024.Solvers
{
    [ProblemDescription("2024 Day 8: Resonant Collinearity")]
    public class Day08 : ISolver
    {
        public Solution Solve()
        {
            var input = FileReader.ReadFileContent("Day08.txt");
            var solution = new Solution
            {
                Part1 = LocateUniqueAntinodes(input),
            };

            return solution;
        }

        public static int LocateUniqueAntinodes(string input)
        {
            var rows = input.Split(["\r\n", "\n"], StringSplitOptions.None);

            var gridRowSize = rows.Length;
            var gridColSize = rows[0].Length;

            var antennas = GetAntennas(rows);
            var groupedAntennas = GroupAntennas(antennas);

            var uniqueAntiNodes = new HashSet<(int row, int col)>();

            foreach (var currentAntenna in antennas)
            {
                if (groupedAntennas.TryGetValue(currentAntenna.frequency, out var positions))
                {
                    foreach (var targetAntenna in positions)
                    {
                        if (targetAntenna.row == currentAntenna.row && targetAntenna.col == currentAntenna.col)
                        {
                            continue;
                        }

                        var delta = (row: currentAntenna.row - targetAntenna.row, col: currentAntenna.col - targetAntenna.col);

                        var potentialAntiNode = (row: currentAntenna.row + delta.row, col: currentAntenna.col + delta.col);

                        if (InGrid(potentialAntiNode, gridRowSize, gridColSize))
                        {
                            uniqueAntiNodes.Add(potentialAntiNode);
                        }
                    }
                }
            }
            return uniqueAntiNodes.Count;
        }

        private static bool InGrid((int row, int col) potentialAntiNode, int gridRowSize, int gridColSize)
        {
            return potentialAntiNode.row >= 0 && potentialAntiNode.row < gridRowSize && potentialAntiNode.col >= 0 && potentialAntiNode.col < gridColSize;
        }

        private static Dictionary<char, List<(int row, int col)>> GroupAntennas(List<(char Freq, int row, int col)> antennas)
        {
            var antennaToRowCol = antennas.GroupBy(t => t.Freq)
                .ToDictionary(g => g.Key, g => g.Select(t => (t.row, t.col))
                .ToList());
            return antennaToRowCol;
        }

        private static List<(char frequency, int row, int col)> GetAntennas(IReadOnlyList<string> input)
        {
            var antennas = input.SelectMany((line, row) => line.Select((ch, col) => (frequency: ch, row, col)))
                .Where(t => t.frequency != '.')
                .ToList();
            return antennas;
        }
    }
}
