using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public interface IParserContext
{
    public IList<ICommand> ConvertToCommands();
}