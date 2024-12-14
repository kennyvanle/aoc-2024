namespace AoC2024.Tests;

[TestClass]
public class Day01Tests
{
    private const string Input = """
                                 3   4
                                 4   3
                                 2   5
                                 1   3
                                 3   9
                                 3   3
                                 """;

    [TestMethod]
    public void It_calculates_the_total_distance_between_the_lists()
    {
        var res = Day01.CalculateTotalDistance(Input);

        const int expected = 11;
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_calculates_the_similarity_score_between_the_lists()
    {
        var res = Day01.CalculateSimilarityScore(Input);

        const int expected = 31;
        res.Should().Be(expected);
    }
}