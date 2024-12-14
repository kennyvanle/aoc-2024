namespace Common;

public interface ISolver
{
    /// <summary>
    /// Solves given Advent of Code problem per daily solver.
    /// </summary>
    /// <returns>
    /// Returns a Solution object which provides solution for each part of the problem.
    /// </returns>
    public Solution Solve();
}