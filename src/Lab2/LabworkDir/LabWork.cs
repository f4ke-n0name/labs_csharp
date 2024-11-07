namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;

public class LabWork : ILabWork
{
    public Guid LabId { get; private set; }

    public Guid? BaseLabId { get; private set; }

    public string LabName { get; private set; }

    public string LabDescription { get; private set; }

    public string EvalCriteria { get; private set; }

    public double NumOfPoints { get; }

    public User Author { get; }

    public LabWork(User author, string name, string description, string criteria, double points, Guid? baseLabId = null)
    {
        LabId = Guid.NewGuid();
        Author = author;
        LabName = name;
        LabDescription = description;
        EvalCriteria = criteria;
        NumOfPoints = points;
        BaseLabId = baseLabId;
    }

    public void ChangeName(string newName, Guid authorId)
    {
        if (authorId != Author.GetUserId())
        {
            throw new Exception("Only author can modify labwork materials.");
        }

        LabName = newName;
    }

    public void ChangeDescription(string newDescription, Guid authorId)
    {
        if (authorId != Author.GetUserId())
        {
            throw new Exception("Only author can modify labwork materials.");
        }

        LabDescription = newDescription;
    }

    public void ChangeCriteria(string newCriteria, Guid authorId)
    {
        if (authorId != Author.GetUserId())
        {
            throw new Exception("Only author can modify labwork materials.");
        }

        EvalCriteria = newCriteria;
    }
}