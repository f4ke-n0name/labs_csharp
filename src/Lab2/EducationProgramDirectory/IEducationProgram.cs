using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public interface IEducationProgram
{
    public void ChangeName(string newName, Guid authorId);

    public void ChangeSubjects(IDictionary<int, IList<Subject>> newSubjectsBySemester, Guid author);

    public IEducationProgram DeepCopy(User author);
}