using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public class EducationProgramCreator : IEducationProgramCreator
{
    private readonly User _eduProgramAuthor;

    public EducationProgramCreator(User author)
    {
        _eduProgramAuthor = author;
    }

    public EducationProgram CreateEduProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        return new EducationProgram(name, subjectsBySemester, responsible);
    }

    public EducationProgram CreateEduProgramFromExisting(EducationProgram existingEducationProgram)
    {
        return (EducationProgram)existingEducationProgram.DeepCopy(_eduProgramAuthor);
    }
}