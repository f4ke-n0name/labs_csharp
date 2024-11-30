namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public record SubjectType()
{
    public sealed record ValidPoints() : SubjectType();

    public sealed record InValidPoints() : SubjectType();
}