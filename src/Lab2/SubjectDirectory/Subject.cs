using Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;

public class Subject : ISubject
{
    public Guid SubjectId { get; }

    public Guid? BaseSubjectId { get; private set; }

    public string SubjectName { get; private set; }

    public User Author { get; }

    public IReadOnlyList<LabWork> LabWorks { get; }

    public IReadOnlyList<Lecture> LectureMaterials { get; private set; }

    public IAssessmentType Assessment { get; private set; }

    public Subject(
        string subjectName,
        User author,
        IReadOnlyList<LabWork> labWorks,
        IReadOnlyList<Lecture> lectureMaterials,
        IAssessmentType assessment,
        Guid? baseSubjectId = null)
    {
        if (string.IsNullOrWhiteSpace(subjectName)) throw new ArgumentNullException(nameof(subjectName));
        SubjectId = Guid.NewGuid();
        SubjectName = subjectName;
        Author = author ?? throw new ArgumentNullException(nameof(author));
        LabWorks = new List<LabWork>(labWorks);
        LectureMaterials = new List<Lecture>(lectureMaterials);
        Assessment = assessment;
        BaseSubjectId = baseSubjectId;
        Validate();
    }

    public void ChangeTitle(string newTitle, Guid authorId)
    {
        if (Author.UserId != authorId)
        {
            throw new Exception("Only author can modify lecture materials.");
        }

        if (string.IsNullOrWhiteSpace(newTitle))
        {
            throw new ArgumentException("Title cannot be empty.");
        }

        SubjectName = newTitle;
    }

    public void ChangeLectureMaterials(ICollection<Lecture> newLectures, Guid authorId)
    {
        if (Author.UserId != authorId)
        {
            throw new UnauthorizedAccessException("Only author can modify subject.");
        }

        LectureMaterials = newLectures?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(newLectures));
    }

    public SubjectType Validate()
    {
        double totalPoints = LabWorks.Sum(lab => lab.NumOfPoints);

        return totalPoints == 100
            ? new SubjectType.ValidPoints()
            : new SubjectType.InValidPoints();
    }
}
