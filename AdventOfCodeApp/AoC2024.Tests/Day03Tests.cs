namespace AoC2024.Tests;

[TestClass]
public class Day03Tests
{
    [TestMethod]
    public void It_sums_the_products()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        const int expected = 161;

        var res = Day03.CalculateSumOfProducts(input);
        res.Should().Be(expected);
    }
    
    [TestMethod]
    public void It_sums_the_products_of_enabled()
    {
        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        const int expected = 48;

        var res = Day03.CalculateSumOfProductsWhenEnabled(input);
        res.Should().Be(expected);
    }
}