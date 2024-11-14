using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public class EducationProgram : IEducationProgram
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public Dictionary<int, List<Subject>> SubjectBySemester { get; private set; }

    public User Responsible { get; }

    public Guid? BaseId { get; }

    public EducationProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Responsible = responsible;
        BaseId = baseId;
        SubjectBySemester = subjectsBySemester ?? throw new ArgumentNullException(nameof(subjectsBySemester));
    }

    public void ChangeName(string newName, Guid authorId)
    {
        if (Responsible.UserId != authorId)
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");

        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public void ChangeSubjects(IDictionary<int, IList<Subject>> newSubjectsBySemester, Guid author)
    {
        if (Responsible.UserId != author)
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");

        if (newSubjectsBySemester == null || newSubjectsBySemester.Count == 0)
            throw new ArgumentException("You must specify subjects by semesters.");

        var readOnlySubjects = new Dictionary<int, IReadOnlyList<Subject>>();
        foreach (KeyValuePair<int, IList<Subject>> kvp in newSubjectsBySemester)
        {
            if (kvp.Key <= 0)
                throw new ArgumentException("Semester number must be greater than 0.");

            if (kvp.Value == null || kvp.Value.Count == 0)
                throw new ArgumentException($"Semester {kvp.Key} does not contain subjects.");

            readOnlySubjects.Add(kvp.Key, kvp.Value.ToList().AsReadOnly());
        }

        SubjectBySemester = new Dictionary<int, List<Subject>>(newSubjectsBySemester.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.ToList()));
    }

    public IEducationProgram DeepCopy(User author)
    {
        return new EducationProgram(
            Name,
            SubjectBySemester.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToList()),
            Responsible,
            Id);
    }
}