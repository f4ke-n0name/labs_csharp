using Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public interface ISubjectFactory
{
    ISubject CreateSubject(
        string name,
        User author,
        IReadOnlyList<LabWork> labWorks,
        IReadOnlyList<Lecture> lectureMaterials,
        Guid? baseSubjectId = null);

    ISubject CreateSubjectFromExisting(Subject originSubject);
}