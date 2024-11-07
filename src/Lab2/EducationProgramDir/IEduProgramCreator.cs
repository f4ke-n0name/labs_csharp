using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;

public interface IEduProgramCreator
{
    EduProgram CreateEduProgram(
        string name,
        Dictionary<int, List<Subject>> subjectsBySemester,
        User responsible,
        Guid? baseId = null);

    EduProgram CreateEduProgramFromExisting(EduProgram existingEduProgram);
}