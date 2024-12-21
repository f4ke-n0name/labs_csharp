namespace Itmo.ObjectOrientedProgramming.Lab4.ParsersType;

public class ConfigParser : IParser
{
    private readonly string _filePath;
    private readonly char _delimiter;

    public ConfigParser(string filePath, char delimiter = ' ')
    {
        _filePath = filePath;
        _delimiter = delimiter;
    }

    public IEnumerable<string> ParseToStrings()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"File {_filePath} not found.");
        }

        string[] inputLines = File.ReadAllLines(_filePath);
        var lines = new List<string>();

        foreach (string line in inputLines)
        {
            string[] arguments = line.Split([_delimiter]);
            lines.AddRange(arguments);
        }

        return lines;
    }
}