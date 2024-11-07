namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;

public interface ILabWorkCreator
{
    LabWork CreateLabwork(string name, string description, string criteria, double points);

    LabWork CreateLabworkFromExisting(LabWork existingLabWork);
}