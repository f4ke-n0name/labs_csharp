using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkDirectory;
using Xunit;

namespace Lab2.Tests;

public class LabWorkTests
{
    [Fact]
    public void ChangeName_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWork = new LabWork(author, "Lab1", "Description1", "Criteria1", 10);

        // Act
        Action act = () => labWork.ChangeName("NewName", nonAuthor.UserId);

        // Assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("Only author can modify labwork materials.", exception.Message);
    }

    [Fact]
    public void ChangeDescription_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWork = new LabWork(author, "Lab1", "Description1", "Criteria1", 10);

        // Act
        Action act = () => labWork.ChangeDescription("NewDescription", nonAuthor.UserId);

        // Assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("Only author can modify labwork materials.", exception.Message);
    }

    [Fact]
    public void ChangeCriteria_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWork = new LabWork(author, "Lab1", "Description1", "Criteria1", 10);

        // Act
        Action act = () => labWork.ChangeCriteria("NewCriteria", nonAuthor.UserId);

        // Assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("Only author can modify labwork materials.", exception.Message);
    }

    [Fact]
    public void CreateLabworkFromExisting_ShouldContainBaseLabId()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWorkCreator = new LabWorkCreator(author);
        var originalLabWork = new LabWork(author, "OriginalLab", "OriginalDescription", "OriginalCriteria", 10);

        // Act
        LabWork clonedLabWork = labWorkCreator.CreateLabworkFromExisting(originalLabWork);

        // Assert
        Assert.Equal(originalLabWork.LabId, clonedLabWork.BaseLabId);
        Assert.NotEqual(originalLabWork.LabId, clonedLabWork.LabId);
    }
}