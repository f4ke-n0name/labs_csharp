namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;

public interface ILabWork
{
    void ChangeName(string newName, Guid authorId);

    void ChangeDescription(string newDescription, Guid authorId);

    void ChangeCriteria(string newCriteria, Guid authorId);
}