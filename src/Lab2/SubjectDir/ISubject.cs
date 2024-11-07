using Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public interface ISubject
{
    void ChangeTitle(string newTitle, Guid authorId);

    void ChangeLectureMaterials(ICollection<Lecture> newLectures, Guid authorId);
}