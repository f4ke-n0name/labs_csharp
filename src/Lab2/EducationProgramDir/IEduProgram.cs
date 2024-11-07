using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;

public interface IEduProgram
{
    public void ChangeName(string newName, Guid authorId);

    public void ChangeSubjects(IDictionary<int, IList<Subject>> newSubjectsBySemester, Guid author);

    public IEduProgram DeepCopy(User author);
}