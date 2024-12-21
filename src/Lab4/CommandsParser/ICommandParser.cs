using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public interface ICommandParser
{
    ICommandParser SetNext(ICommandParser parser);

    CommandType Parse(IList<string> args);
}