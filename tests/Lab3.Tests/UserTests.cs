using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using Itmo.ObjectOrientedProgramming.Lab3.UserLib;
using Xunit;

namespace Lab3.Tests;

public class UserTests
    {
        [Fact]
        public void Test_GetMessage_SavesAsUnread()
        {
            // Arrange
            var user = new User("TestUser");
            var builder = new Message.MessageBuilder();
            builder.SetHeader("Test");
            builder.SetBody("Hello world.");
            builder.SetRelevance(3);
            Message message = builder.Build();

            // Act
            user.GetMessage(message);

            // Assert
            var unreadStatus = new UserMessageType.Delivered();
            UserMessageStatusInfo messageInfo = user.UserMessages.Single();

            Assert.Equal(unreadStatus, messageInfo.Status);
            Assert.Equal(message, messageInfo.Message);
        }

        [Fact]
        public void Test_MakeMarkedMessage_ChangesFromUnreadToRead()
        {
            // Arrange
            var user = new User("TestUser");
            var builder = new Message.MessageBuilder();
            builder.SetHeader("Test");
            builder.SetBody("Hello world.");
            builder.SetRelevance(3);
            Message message = builder.Build();
            user.GetMessage(message);

            // Act
            UserMessageType result = user.MakeMarkedMessage(message);

            // Assert
            var readStatus = new UserMessageType.Read();
            UserMessageStatusInfo messageInfo = user.UserMessages.Single();

            Assert.Equal(readStatus, messageInfo.Status);
            Assert.Equal(result, readStatus);
        }

        [Fact]
        public void Test_MakeMarkedMessage_ReadAgainReturnsFail()
        {
            // Arrange
            var user = new User("TestUser");
            var builder = new Message.MessageBuilder();
            builder.SetHeader("Test");
            builder.SetBody("Hello world.");
            builder.SetRelevance(3);
            Message message = builder.Build();
            user.GetMessage(message);
            user.MakeMarkedMessage(message);

            // Act
            UserMessageType result = user.MakeMarkedMessage(message);

            // Assert
            var failedStatus = new UserMessageType.Failed();

            Assert.Equal(failedStatus, result);
        }
    }
