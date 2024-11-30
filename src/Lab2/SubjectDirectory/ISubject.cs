using Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

public interface ISubject
{
    void ChangeTitle(string newTitle, Guid authorId);

    void ChangeLectureMaterials(ICollection<Lecture> newLectures, Guid authorId);
}