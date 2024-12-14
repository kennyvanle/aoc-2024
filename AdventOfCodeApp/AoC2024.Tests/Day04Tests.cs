namespace AoC2024.Tests;

[TestClass]
public class Day04Tests
{
    private const string Input = """
                                 MMMSXXMASM
                                 MSAMXMSMSA
                                 AMXSXMAAMM
                                 MSAMASMSMX
                                 XMASAMXAMM
                                 XXAMMXXAMA
                                 SMSMSASXSS
                                 SAXAMASAAA
                                 MAMMMXMMMM
                                 MXMXAXMASX
                                 """;

    [TestMethod]
    public void It_finds_all_xmas_count()
    {
        const int expected = 18;
        var res = Day04.FindAllXmas(Input);
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_finds_all_xmas_count_part_2()
    {
        const int expected = 9;
        var res = Day04.FindAllXmasPart2(Input);
        res.Should().Be(expected);
    }
}