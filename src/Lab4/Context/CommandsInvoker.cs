using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public class CommandsInvoker
{
    private readonly IList<ICommand> _commands;

    public CommandsInvoker()
    {
        _commands = new List<ICommand>();
    }

    public CommandsInvoker(IList<ICommand> commands)
    {
        _commands = commands;
    }

    public void AddCommand(ICommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command), "Command cannot be null");

        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        IFileSystem fileSystem = GetFileSystem();
        foreach (ICommand command in _commands)
        {
            command.Execute(fileSystem);
        }

        _commands.Clear();
    }

    private IFileSystem GetFileSystem()
    {
        ConnectCommand? connect = _commands.OfType<ConnectCommand>().FirstOrDefault();
        return connect != null ? connect.FileSystem : throw new InvalidOperationException();
    }
}