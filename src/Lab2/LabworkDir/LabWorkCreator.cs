namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;

public class LabWorkCreator : ILabWorkCreator
{
    private readonly User _labWorkAuthor;

    public LabWorkCreator(User author)
    {
        _labWorkAuthor = author;
    }

    public LabWork CreateLabwork(
        string name,
        string description,
        string criteria,
        double points)
    {
        return new LabWork(_labWorkAuthor, name, description, criteria, points);
    }

    public LabWork CreateLabworkFromExisting(LabWork existingLabWork)
    {
        return new LabWork(
            _labWorkAuthor,
            existingLabWork.LabName,
            existingLabWork.LabDescription,
            existingLabWork.EvalCriteria,
            existingLabWork.NumOfPoints,
            existingLabWork.LabId);
    }
}