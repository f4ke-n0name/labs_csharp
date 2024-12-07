namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    string CurrentPath { get; }

    void Disconnect();

    void MoveFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void CopyFile(string sourcePath, string destinationPath);

    void ChangeDirectory(string destinationPath);

    void ShowFile(string path);

    void Write(string content);

    bool FileExists(string path);

    bool DirectoryExists(string path);

    string[] GetFiles(string path);

    string[] GetDirectories(string path);

    string GetFileName(string path);

    void SetCurrentDirectory(string path);

    public string Combine(string destinationPath, string fileName);

    public string? GetDirectoryName(string path);
}