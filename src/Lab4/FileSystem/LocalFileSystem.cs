namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public string CurrentPath { get; private set; }

    public string OriginPath { get; private set; }

    public LocalFileSystem(string absolutePath, string currentPath)
    {
        OriginPath = absolutePath;
        CurrentPath = currentPath;
    }

    public void Disconnect()
    {
        OriginPath = string.Empty;
        CurrentPath = string.Empty;
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void ChangeDirectory(string destinationPath)
    {
        if (!File.Exists(destinationPath))
        {
            CurrentPath = destinationPath;
        }
    }

    public void ShowFile(string path)
    {
        string fileContent = File.ReadAllText(path);
        Console.WriteLine(fileContent);
    }

    public void Write(string content)
    {
        Console.WriteLine(content);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    public void SetCurrentDirectory(string path)
    {
        CurrentPath = path;
    }

    public string Combine(string destinationPath, string fileName)
    {
        return Path.Combine(destinationPath, fileName);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }
}