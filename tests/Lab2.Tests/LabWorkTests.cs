using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;
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

        // Act & Assert
        Assert.Throws<Exception>(() =>
            labWork.ChangeName("NewName", nonAuthor.GetUserId()));
    }

    [Fact]
    public void ChangeDescription_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWork = new LabWork(author, "Lab1", "Description1", "Criteria1", 10);

        // Act & Assert
        Assert.Throws<Exception>(() =>
            labWork.ChangeDescription("NewDescription", nonAuthor.GetUserId()));
    }

    [Fact]
    public void ChangeCriteria_ByNonAuthor_ShouldThrowException()
    {
        // Arrange
        var author = new User(Guid.NewGuid(), "Author");
        var nonAuthor = new User(Guid.NewGuid(), "NonAuthor");
        var labWork = new LabWork(author, "Lab1", "Description1", "Criteria1", 10);

        // Act & Assert
        Assert.Throws<Exception>(() =>
            labWork.ChangeCriteria("NewCriteria", nonAuthor.GetUserId()));
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