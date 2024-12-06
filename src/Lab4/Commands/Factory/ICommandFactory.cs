namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Factory;

public interface ICommandFactory
{
    ICommand CreateCommand(CommandType commandType);
}