namespace AoC2024.Tests;

[TestClass]
public class Day06Tests
{
    private const string Input = """
                                 ....#.....
                                 .........#
                                 ..........
                                 ..#.......
                                 .......#..
                                 ..........
                                 .#..^.....
                                 ........#.
                                 #.........
                                 ......#...
                                 """;
    
    [TestMethod]
    public void It_counts_distinct_positions()
    {
        const int expected = 41;
        var res = Day06.DetermineDistinctPositions(Input);
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_counts_distinct_obstructions()
    {
        const int expected = 6;
        var res = Day06.DetermineDistinctObstructions(Input);
        res.Should().Be(expected);
    }
}