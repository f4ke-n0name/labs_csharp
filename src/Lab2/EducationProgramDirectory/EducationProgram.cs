namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public class EducationProgram : IEducationProgram
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public IList<SubjectBySemester> SubjectsBySemester { get; private set; }

    public User Responsible { get; }

    public Guid? BaseId { get; }

    public EducationProgram(
        string name,
        IList<SubjectBySemester> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Responsible = responsible;
        BaseId = baseId;
        SubjectsBySemester = subjectsBySemester ?? throw new ArgumentNullException(nameof(subjectsBySemester));
    }

    public void ChangeName(string newName, Guid authorId)
    {
        if (Responsible.UserId != authorId)
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");

        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public void ChangeSubjects(IList<SubjectBySemester> newSubjectsBySemester, Guid author)
    {
        if (Responsible.UserId != author)
            throw new UnauthorizedAccessException("Only the program leader can modify the program.");

        if (newSubjectsBySemester == null || newSubjectsBySemester.Count == 0)
            throw new ArgumentException("You must specify subjects by semesters.");

        SubjectsBySemester = newSubjectsBySemester;
    }

    public EducationProgram DeepCopy(User author)
    {
        return new EducationProgram(
            Name,
            SubjectsBySemester.Select(s => new SubjectBySemester(s.Semester, s.Subjects)).ToList(),
            Responsible,
            Id);
    }
}