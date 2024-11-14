using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public interface IEducationProgramCreator
{
    EducationProgram CreateEduProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null);

    EducationProgram CreateEduProgramFromExisting(EducationProgram existingEducationProgram);
}