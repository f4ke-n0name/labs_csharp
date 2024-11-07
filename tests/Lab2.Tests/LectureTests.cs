using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.LectureDir;
using Xunit;

namespace Lab2.Tests;

public class LectureTests
{
    [Fact]
    public void ChangeName_ByNonAuthor_ShouldThrowException()
    {
    // Arrange
    var author = new User(Guid.NewGuid(), "Author");
    var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
    var lecture = new Lecture("Lecture1", "Description1", "Content1", author);

    // Act & Assert
    Assert.Throws<Exception>(() =>
        lecture.ChangeName("NewName", nonAuthor.GetUserId()));
    }

    [Fact]
    public void ChangeDescription_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var lecture = new Lecture("Lecture1", "Description1", "Content1", author);

        // Act & Assert
        Assert.Throws<Exception>(() =>
            lecture.ChangeDescription("NewDescription", nonAuthor.GetUserId()));
    }

    [Fact]
    public void ChangeContent_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var lecture = new Lecture("Lecture1", "Description1", "Content1", author);

        // Act & Assert
        Assert.Throws<Exception>(() =>
            lecture.ChangeContent("NewContent", nonAuthor.GetUserId()));
    }

    [Fact]
    public void Clone_ShouldContainBaseLectureId()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var originalLecture = new Lecture("OriginalLecture", "OriginalDescription", "OriginalContent", author);

        // Act
        Lecture clonedLecture = originalLecture.Clone();

        // Assert
        Assert.Equal(originalLecture.LectureId, clonedLecture.BaseLectureId);
        Assert.NotEqual(originalLecture.LectureId, clonedLecture.LectureId);
    }
}