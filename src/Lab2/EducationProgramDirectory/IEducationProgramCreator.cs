namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public interface IEducationProgramCreator
{
    EducationProgram CreateEduProgram(
        string name,
        IList<SubjectBySemester> subjectsBySemester,
        User responsible,
        Guid? baseId = null);

    EducationProgram CreateEduProgramFromExisting(EducationProgram existingEducationProgram);
}