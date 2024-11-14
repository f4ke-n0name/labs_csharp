using Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

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