namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;

public interface ILabWork
{
    void ChangeName(string newName, Guid authorId);

    void ChangeDescription(string newDescription, Guid authorId);

    void ChangeCriteria(string newCriteria, Guid authorId);
}