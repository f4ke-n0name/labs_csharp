using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public abstract class CommandParserBase : ICommandParser
{
    protected ICommandParser? Next { get; private set; }

    public ICommandParser SetNext(ICommandParser parser)
    {
        if (Next is null)
        {
            Next = parser;
        }
        else
        {
            Next.SetNext(parser);
        }

        return this;
    }

    public abstract CommandType Parse(IList<string> args);
}