using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class WriteInFile : IWriteIn
{
    private readonly string _filePath;

    public WriteInFile(string filePath)
    {
        _filePath = filePath;
    }

    public void PrintMessage(Message message)
    {
        File.AppendAllText(_filePath, message + Environment.NewLine);
    }

    public void Clear()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }

        File.Create(_filePath).Close();
    }
}