namespace AoC2024.Tests;

[TestClass]
public class Day02Tests
{
    private const string Input = """
                                 7 6 4 2 1
                                 1 2 7 8 9
                                 9 7 6 2 1
                                 1 3 2 4 5
                                 8 6 4 4 1
                                 1 3 6 7 9
                                 """;
        
    [TestMethod]
    public void It_calculates_safe_reports()
    {
        var result = Day02.CalculateSafeReports(Input);
        const int expected = 2;
        result.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_calculates_safe_reports_with_tolerance()
    {
        var result = Day02.CalculateSafeReports(Input, true);
        const int expected = 4;
        result.Should().Be(expected);
    }
}