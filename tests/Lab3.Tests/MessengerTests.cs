using Itmo.ObjectOrientedProgramming.Lab3.MessangerLib;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void Test_SendMessageInService_CallsExpectedMethod()
    {
        // Arrange
        var mockMessanger = new Mock<IMessenger>();
        string testMessage = "Hello world";

        // Act
        mockMessanger.Object.SendMessageInService(testMessage);

        // Assert
        mockMessanger.Verify(m => m.SendMessageInService(It.Is<string>(msg => msg == testMessage)), Times.Once);
    }
}