namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Factory;

public class CommandFactory : ICommandFactory
{
    public ICommand CreateCommand(CommandType commandType)
    {
        return commandType switch
        {
            CommandType.Connect connect => new ConnectCommand(connect),
            CommandType.Success => new DisconnectCommand(),
            CommandType.FileCopy fileCopy => new FileCopyCommand(fileCopy),
            CommandType.FileDelete fileDelete => new FileDeleteCommand(fileDelete),
            CommandType.FileMove fileMove => new FileMoveCommand(fileMove),
            CommandType.FileRename fileRename => new FileRenameCommand(fileRename),
            CommandType.FileShow fileShow => new FileShowCommand(fileShow),
            CommandType.TreeGoto treeGoto => new TreeGotoCommand(treeGoto),
            CommandType.TreeList treeList => new TreeListCommand(treeList),
            _ => throw new ArgumentException("Unknown command type", nameof(commandType)),
        };
    }
}