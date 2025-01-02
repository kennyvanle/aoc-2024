namespace AoC2024.Tests;

[TestClass]
public class Day07Tests
{
    private const string Input = """
                                 190: 10 19
                                 3267: 81 40 27
                                 83: 17 5
                                 156: 15 6
                                 7290: 6 8 6 15
                                 161011: 16 10 13
                                 192: 17 8 14
                                 21037: 9 7 18 13
                                 292: 11 6 16 20
                                 """;
    
    [TestMethod]
    public void It_determines_calibration()
    {
        const int expected = 3749;
        var res = Day07.DetermineCalibration(Input);
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_determines_calibration_with_concatenation()
    {
        const int expected = 11387;
        var res = Day07.DetermineCalibrationWithConcatenation(Input);
        res.Should().Be(expected);
    }
}