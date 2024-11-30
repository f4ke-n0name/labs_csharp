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
        Action act = () => eduProgram.ChangeSubjects(new List<SubjectBySemester>(), _nonResponsibleUser.UserId);

        // Assert
        UnauthorizedAccessException exception = Assert.Throws<UnauthorizedAccessException>(act);
        Assert.Equal("Only the program leader can modify the program.", exception.Message);
    }

    [Fact]
    public void SubjectBySemester_WithInvalidSemesterNumber_ShouldThrowException()
    {
        // Arrange
        var subjects = new List<Subject>
        {
            new Subject("Subject1", _responsibleUser, new List<LabWork>(), new List<Lecture>(), new Exam(50)),
        };

        // Act
        Action act = () => new SubjectBySemester(-1, subjects);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Semester number must be greater than 0.", exception.Message);
    }

    [Fact]
    public void SubjectBySemester_WithEmptySubjects_ShouldThrowException()
    {
        // Arrange
        var eduProgram = new EducationProgram("EduProgram1", GetSampleSubjects(), _responsibleUser);

        // Act
        Action act = () => new SubjectBySemester(1, new List<Subject>());

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Subjects list cannot be empty.", exception.Message);
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

    private List<SubjectBySemester> GetSampleSubjects()
    {
        var labWorks = new List<LabWork> { new LabWork(_responsibleUser, "Lab1", "Description", "Criteria", 10) };
        var lectures = new List<Lecture> { new Lecture("Lecture1", "Description", "Content", _responsibleUser) };
        var assessment = new Credit(50);

        return new List<SubjectBySemester>
        {
            new SubjectBySemester(1, new List<Subject> { new Subject("Subject1", _responsibleUser, labWorks, lectures, assessment) }),
            new SubjectBySemester(2, new List<Subject> { new Subject("Subject2", _responsibleUser, labWorks, lectures, assessment) }),
        };
    }
}