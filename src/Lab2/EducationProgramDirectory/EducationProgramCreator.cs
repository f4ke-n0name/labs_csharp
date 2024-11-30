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
        IList<SubjectBySemester> subjectsBySemester,
        User responsible,
        Guid? baseId = null)
    {
        return new EducationProgram(name, subjectsBySemester, responsible);
    }

    public EducationProgram CreateEduProgramFromExisting(EducationProgram existingEducationProgram)
    {
        return existingEducationProgram.DeepCopy(_eduProgramAuthor);
    }
}