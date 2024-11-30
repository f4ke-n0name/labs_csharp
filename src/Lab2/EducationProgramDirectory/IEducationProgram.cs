namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public interface IEducationProgram
{
    public void ChangeName(string newName, Guid authorId);

    public void ChangeSubjects(IList<SubjectBySemester> newSubjectsBySemester, Guid author);

    public EducationProgram DeepCopy(User author);
}