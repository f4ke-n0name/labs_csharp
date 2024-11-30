using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public class SubjectBySemester
{
    public int Semester { get; }

    public IList<Subject> Subjects { get; }

    public SubjectBySemester(int semester, IList<Subject> subjects)
    {
        if (semester <= 0)
            throw new ArgumentException("Semester number must be greater than 0.");

        Semester = semester;
        Subjects = subjects ?? throw new ArgumentNullException(nameof(subjects));
        if (Subjects.Count == 0)
            throw new ArgumentException("Subjects list cannot be empty.");
    }
}