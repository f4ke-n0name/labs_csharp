using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDir;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;
using Xunit;

namespace Lab2.Tests;

public class EduProgramTests
{
    private readonly User _responsibleUser = new User(Guid.NewGuid(), "ResponsibleUser");
    private readonly User _nonResponsibleUser = new User(Guid.NewGuid(), "NonResponsibleUser");

    [Fact]
    public void ChangeName_ByNonResponsibleUser_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EduProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);

        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() =>
            eduProgram.ChangeName("NewProgramName", _nonResponsibleUser.GetUserId()));
    }

    [Fact]
    public void ChangeSubjects_ByNonResponsibleUser_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EduProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);

        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() =>
            eduProgram.ChangeSubjects(new Dictionary<int, IList<Subject>>(), _nonResponsibleUser.GetUserId()));
    }

    [Fact]
    public void ChangeSubjects_WithInvalidSemesterNumber_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EduProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);
        var invalidSubjects = new Dictionary<int, IList<Subject>>
        {
            { -1, new List<Subject> { new Subject("Subject1", _responsibleUser, new List<LabWork>(), new List<Lecture>(), new Exam(50)) } },
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            eduProgram.ChangeSubjects(invalidSubjects, _responsibleUser.GetUserId()));
    }

    [Fact]
    public void ChangeSubjects_WithEmptySubjects_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EduProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);
        var invalidSubjects = new Dictionary<int, IList<Subject>>
        {
            { 1, new List<Subject>() },
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            eduProgram.ChangeSubjects(invalidSubjects, _responsibleUser.GetUserId()));
    }

    [Fact]
    public void CreateEduProgramFromExisting_ShouldContainBaseId()
    {
        // Arrange
        var eduProgramCreator = new EduProgramCreator(_responsibleUser);
        var originalEduProgram = new EduProgram("OriginalEduProgram", GetSampleSubjects(), _responsibleUser);

        // Act
        EduProgram clonedEduProgram = eduProgramCreator.CreateEduProgramFromExisting(originalEduProgram);

        // Assert
        Assert.Equal(originalEduProgram.Id, clonedEduProgram.BaseId);
        Assert.NotEqual(originalEduProgram.Id, clonedEduProgram.Id);
    }

    private Dictionary<int, List<Subject>> GetSampleSubjects()
    {
        var labWorks = new List<LabWork> { new LabWork(_responsibleUser, "Lab1", "Description", "Criteria", 10) };
        var lectures = new List<Lecture> { new Lecture("Lecture1", "Description", "Content", _responsibleUser) };
        var assessment = new Credit(50);

        return new Dictionary<int, List<Subject>>
        {
            { 1, new List<Subject> { new Subject("Subject1", _responsibleUser, labWorks, lectures, assessment) } },
            { 2, new List<Subject> { new Subject("Subject2", _responsibleUser, labWorks, lectures, assessment) } },
        };
    }
}