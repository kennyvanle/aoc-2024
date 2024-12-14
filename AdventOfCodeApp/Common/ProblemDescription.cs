namespace Common;

public class ProblemDescription(string name) : Attribute
{
    public readonly string Name = name;
}