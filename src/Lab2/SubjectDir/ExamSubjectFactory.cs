using Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class ExamSubjectFactory : ISubjectFactory
{
    private readonly Exam _assessment;

    public ExamSubjectFactory(double points)
    {
        _assessment = new Exam(points);
    }

    public ISubject CreateSubject(
        string name,
        User author,
        IReadOnlyList<LabWork> labWorks,
        IReadOnlyList<Lecture> lectureMaterials,
        Guid? baseSubjectId = null)
    {
        return new Subject(name, author, labWorks, lectureMaterials, _assessment, baseSubjectId);
    }

    public ISubject CreateSubjectFromExisting(Subject originSubject)
    {
        var newLabWorks = originSubject.LabWorks.Select(lab =>
                new LabWork(
                    lab.Author,
                    lab.LabName,
                    lab.LabDescription,
                    lab.EvalCriteria,
                    lab.NumOfPoints,
                    lab.LabId)).ToList();

        var newLectures = originSubject.LectureMaterials.Select(lecture =>
                new Lecture(
                    lecture.LectureName,
                    lecture.LectureDescription,
                    lecture.LectureContent,
                    lecture.Author,
                    lecture.LectureId)).ToList();
        return new Subject(
            originSubject.SubjectName,
            originSubject.Author,
            newLabWorks,
            newLectures,
            originSubject.Assessment,
            originSubject.SubjectId);
    }
}