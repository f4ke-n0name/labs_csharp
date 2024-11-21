using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class RecipientTests
{
    [Fact]
    public void SendMessage_Should_Log_Message_Details()
    {
        // Arrange
        var recipientMock = new Mock<IRecipient>();
        var loggingRecipient = new LoggingRecipientDecorator(recipientMock.Object);
        var message = new Message("Test Header", "Test Body", 1);

        // Act
        loggingRecipient.SendMessage(message);

        // Assert
        recipientMock.Verify(
            r =>
                r.SendMessage(It.Is<Message>(m => m.Header == message.Header && m.Body == message.Body)),
            Times.Once);
    }

    [Fact]
    public void SendMessage_Should_Not_Send_When_Importance_Is_Lower_Than_Filter()
    {
        // Arrange
        var recipientMock = new Mock<IRecipient>();
        var lowImportanceMessage = new Message("Low Importance", "This is a low importance message.", 3);
        uint relevancePriority = 5;
        var recipientWithFilter = new RecipientFilter(recipientMock.Object, relevancePriority);

        // Act
        recipientWithFilter.SendMessage(lowImportanceMessage);

        // Assert
        recipientMock.Verify(r => r.SendMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void SendMessage_Should_Send_When_Importance_Is_Equal_Or_Higher_Than_Filter()
    {
        // Arrange
        var recipientMock = new Mock<IRecipient>();
        var highImportanceMessage = new Message("High Importance", "This is a high importance message.", 5);
        uint relevancePriority = 5;

        var recipientWithFilter = new RecipientFilter(recipientMock.Object, relevancePriority);

        // Act
        recipientWithFilter.SendMessage(highImportanceMessage);

        // Assert
        recipientMock.Verify(
            r =>
                r.SendMessage(It.Is<Message>(m =>
                    m.Header == highImportanceMessage.Header && m.Body == highImportanceMessage.Body)),
            Times.Once);
    }

    [Fact]
    public void SendMessage_Should_Send_To_Recipient_Without_Filter_Only_When_Importance_Is_Lower_Than_Filter()
    {
        // Arrange
        var recipientWithFilterMock = new Mock<IRecipient>();
        var recipientWithoutFilterMock = new Mock<IRecipient>();

        var lowImportanceMessage = new Message("Low Importance", "This is a low importance message.", 3);
        uint relevancePriority = 5;
        var recipientWithFilter = new RecipientFilter(recipientWithFilterMock.Object, relevancePriority);

        // Act
        recipientWithFilter.SendMessage(lowImportanceMessage);
        recipientWithoutFilterMock.Object.SendMessage(lowImportanceMessage);

        // Assert
        recipientWithFilterMock.Verify(
            r => r.SendMessage(It.IsAny<Message>()),
            Times.Never);
        recipientWithoutFilterMock.Verify(
            r =>
                r.SendMessage(It.Is<Message>(m =>
                    m.Header == lowImportanceMessage.Header && m.Body == lowImportanceMessage.Body)),
            Times.Once);
    }
}