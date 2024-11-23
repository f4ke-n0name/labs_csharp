using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectDirectory;
using Xunit;

namespace Lab2.Tests;

public class SubjectTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreatesSubjectSuccessfully()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Anton Karavaev");
        string criteria = "Test";
        var labWorks = new List<LabWork>
        {
            new LabWork(author, "Lab 1", "Description 1", criteria, 50),
            new LabWork(author, "Lab 2", "Description 2", criteria, 50),
        };
        var lectureMaterials = new List<Lecture>
        {
            new Lecture("Introduction to Subject", "Basics of subject", "Content 1", author),
            new Lecture("Advanced Topics", "In-depth subject concepts", "Content 2", author),
        };
        var assessment = new Credit(100);
        string subjectName = "Test Subject";

        // Act
        var subject = new Subject(subjectName, author, labWorks, lectureMaterials, assessment);

        // Assert
        Assert.Equal(subjectName, subject.SubjectName);
        Assert.Equal(author, subject.Author);
        Assert.Equal(labWorks, subject.LabWorks);
        Assert.Equal(lectureMaterials, subject.LectureMaterials);
        Assert.Equal(assessment, subject.Assessment);
    }

    [Fact]
    public void Constructor_InvalidTotalPoints_ShouldThrowsInValidPoints()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Vadim Pavlov");
        string criteria = "Credit";
        var labWorks = new List<LabWork>
        {
            new LabWork(author, "Lab 1", "Description 1",  criteria, 50),
            new LabWork(author, "Lab 2", "Description 2", criteria, 40),
        };
        var lectureMaterials = new List<Lecture>
        {
            new Lecture("Lecture 1", "Introductory Material", "Content 1", author),
        };
        var assessment = new Credit(100);
        var subject = new Subject("Invalid Points Subject", author, labWorks, lectureMaterials, assessment);

        // Act & Assert
        Assert.Equal(subject.Validate(), new SubjectType.InValidPoints());
    }

    [Fact]
    public void ChangeTitle_NotAuthor_ShouldThrowsException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Vladimir Chashko");
        var anotherUser = new User(Guid.NewGuid(), "Anton Karavaev");
        string criteria = "Test";
        var labWorks = new List<LabWork>
        {
            new LabWork(author, "Lab 1", "Description 1", criteria, 50),
            new LabWork(author, "Lab 2", "Description 2", criteria, 50),
        };
        var lectureMaterials = new List<Lecture>
        {
            new Lecture("Lecture 1", "Introductory Material", "Content 1", author),
        };
        var assessment = new Credit(100);
        var subject = new Subject("Original Subject", author, labWorks, lectureMaterials, assessment);

        // Act
        Action act = () => subject.ChangeTitle("New Subject Name", anotherUser.UserId);

        // Assert
        Assert.Throws<Exception>(act);
    }

    [Fact]
    public void CreateSubjectFromExisting_ShouldCopyContainsBaseId()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Andrey Karchevskiy");
        string criteria = "Test";
        var labWorks = new List<LabWork>
        {
            new LabWork(author, "Lab 1", "Description 1", criteria, 50),
            new LabWork(author, "Lab 2", "Description 2", criteria, 50),
        };
        var lectureMaterials = new List<Lecture>
        {
            new Lecture("Lecture 1", "Introductory Material", "Content 1", author),
            new Lecture("Lecture 2", "Advanced Material", "Content 2", author),
        };
        var assessment = new Exam(100);
        var originalSubject = new Subject("Original Subject", author, labWorks, lectureMaterials, assessment);
        var subjectFactory = new ExamSubjectFactory(assessment.Points);

        // Act
        var copiedSubject = (Subject)subjectFactory.Clone(originalSubject);

        // Assert
        Assert.Equal(originalSubject.SubjectId, copiedSubject.BaseSubjectId);
        Assert.NotEqual(originalSubject.SubjectId, copiedSubject.SubjectId);
        Assert.All(
            originalSubject.LectureMaterials.Zip(copiedSubject.LectureMaterials),
            pair => Assert.Equal(pair.First.LectureId, pair.Second.BaseLectureId));
    }
}