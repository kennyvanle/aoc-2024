namespace AoC2024.Tests;

[TestClass]
public class Day05Tests
{
    private const string Input = """
                                 47|53
                                 97|13
                                 97|61
                                 97|47
                                 75|29
                                 61|13
                                 75|53
                                 29|13
                                 97|29
                                 53|29
                                 61|53
                                 97|53
                                 61|29
                                 47|13
                                 75|47
                                 97|75
                                 47|61
                                 75|61
                                 47|29
                                 75|13
                                 53|13
                                 
                                 75,47,61,53,29
                                 97,61,53,29,13
                                 75,29,13
                                 75,97,47,61,53
                                 61,13,29
                                 97,13,75,29,47
                                 """;
    
    [TestMethod]
    public void It_sums_valid_middle_numbers()
    {
        const int expected = 143;
        var res = Day05.SumValidInstructions(Input);
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_sums_valid_middle_numbers_for_fixed_instructions()
    {
        const int expected = 123;
        var res = Day05.SumFixedInstructions(Input);
        res.Should().Be(expected);
    }
}