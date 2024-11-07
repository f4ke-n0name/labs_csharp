using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;

public class EduProgram : IEduProgram
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public ReadOnlyDictionary<int, IReadOnlyList<Subject>> SubjectBySemester { get; private set; }

    public User Responsible { get; }

    public Guid? BaseId { get; }

    public EduProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Responsible = responsible;
        BaseId = baseId;
        SubjectBySemester = new ReadOnlyDictionary<int, IReadOnlyList<Subject>>(
            subjectsBySemester.ToDictionary(
                kvp => kvp.Key,
                kvp => (IReadOnlyList<Subject>)kvp.Value.ToList().AsReadOnly()));
    }

    public void ChangeName(string newName, Guid authorId)
    {
        if (Responsible.GetUserId() != authorId)
        {
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");
        }

        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public void ChangeSubjects(IDictionary<int, IList<Subject>> newSubjectsBySemester, Guid author)
    {
        if (Responsible.GetUserId() != author)
        {
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");
        }

        if (newSubjectsBySemester == null || newSubjectsBySemester.Count == 0)
        {
            throw new ArgumentException("You must specify subjects by semesters.", nameof(newSubjectsBySemester));
        }

        var readOnlySubjects = new Dictionary<int, IReadOnlyList<Subject>>();
        foreach (KeyValuePair<int, IList<Subject>> kvp in newSubjectsBySemester)
        {
            if (kvp.Key <= 0)
            {
                throw new ArgumentException("Semester number must be greater than 0.", nameof(newSubjectsBySemester));
            }

            if (kvp.Value == null || kvp.Value.Count == 0)
            {
                throw new ArgumentException($"Semester {kvp.Key} does not contain subjects.", nameof(newSubjectsBySemester));
            }

            readOnlySubjects.Add(kvp.Key, kvp.Value.ToList().AsReadOnly());
        }

        SubjectBySemester = new ReadOnlyDictionary<int, IReadOnlyList<Subject>>(readOnlySubjects);
    }

    public IEduProgram DeepCopy(User author)
    {
        return new EduProgram(
            Name,
            SubjectBySemester.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToList()),
            Responsible,
            Id);
    }
}