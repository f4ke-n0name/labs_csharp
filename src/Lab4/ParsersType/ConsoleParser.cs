namespace Itmo.ObjectOrientedProgramming.Lab4.ParsersType;

public class ConsoleParser : IParser
{
    private readonly string[] _args;

    public ConsoleParser(string[] args)
    {
        _args = args;
    }

    public IEnumerable<string> ParseToStrings()
    {
        var lines = new List<string>();

        if (_args.Length > 0)
        {
            lines.AddRange(_args);
        }

        return lines;
    }
}