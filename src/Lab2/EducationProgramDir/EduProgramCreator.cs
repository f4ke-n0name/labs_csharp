using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;

public class EduProgramCreator : IEduProgramCreator
{
    private readonly User _eduProgramAuthor;

    public EduProgramCreator(User author)
    {
        _eduProgramAuthor = author;
    }

    public EduProgram CreateEduProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        return new EduProgram(name, subjectsBySemester, responsible);
    }

    public EduProgram CreateEduProgramFromExisting(EduProgram existingEduProgram)
    {
        return (EduProgram)existingEduProgram.DeepCopy(_eduProgramAuthor);
    }
}