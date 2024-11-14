using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;
using Xunit;

namespace Lab2.Tests;

public class EducationProgramTests
{
    private readonly User _responsibleUser = new User(Guid.NewGuid(), "ResponsibleUser");
    private readonly User _nonResponsibleUser = new User(Guid.NewGuid(), "NonResponsibleUser");

    [Fact]
    public void ChangeName_ByNonResponsibleUser_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EducationProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);

        // Act
        Action act = () => eduProgram.ChangeName("NewProgramName", _nonResponsibleUser.UserId);

        // Assert
        UnauthorizedAccessException exception = Assert.Throws<UnauthorizedAccessException>(act);
        Assert.Equal("Only the program leader can modify the program.", exception.Message);
    }

    [Fact]
    public void ChangeSubjects_ByNonResponsibleUser_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EducationProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);

        // Act
        Action act = () => eduProgram.ChangeSubjects(new Dictionary<int, IList<Subject>>(), _nonResponsibleUser.UserId);

        // Assert
        UnauthorizedAccessException exception = Assert.Throws<UnauthorizedAccessException>(act);
        Assert.Equal("Only the program leader can modify the program.", exception.Message);
    }

    [Fact]
    public void ChangeSubjects_WithInvalidSemesterNumber_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EducationProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);
        var invalidSubjects = new Dictionary<int, IList<Subject>>
        {
            { -1, new List<Subject> { new Subject("Subject1", _responsibleUser, new List<LabWork>(), new List<Lecture>(), new Exam(50)) } },
        };

        // Act
        Action act = () => eduProgram.ChangeSubjects(invalidSubjects, _responsibleUser.UserId);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Semester number must be greater than 0.", exception.Message);
    }

    [Fact]
    public void ChangeSubjects_WithEmptySubjects_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EducationProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);
        var invalidSubjects = new Dictionary<int, IList<Subject>>
        {
            { 1, new List<Subject>() },
        };

        // Act
        Action act = () => eduProgram.ChangeSubjects(invalidSubjects, _responsibleUser.UserId);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Semester 1 does not contain subjects.", exception.Message);
    }

    [Fact]
    public void CreateEduProgramFromExisting_ShouldContainBaseId()
    {
        // Arrange
        var eduProgramCreator = new EducationProgramCreator(_responsibleUser);
        var originalEduProgram = new EducationProgram("OriginalEduProgram", GetSampleSubjects(), _responsibleUser);

        // Act
        EducationProgram clonedEducationProgram = eduProgramCreator.CreateEduProgramFromExisting(originalEduProgram);

        // Assert
        Assert.Equal(originalEduProgram.Id, clonedEducationProgram.BaseId);
        Assert.NotEqual(originalEduProgram.Id, clonedEducationProgram.Id);
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