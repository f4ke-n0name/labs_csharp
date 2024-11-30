namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerLib;

public class Messenger : IMessenger
{
    private readonly string _serviceName;
    private readonly IMessenger _messenger;

    public Messenger(IMessenger messenger, string serviceName)
    {
        _messenger = messenger;
        _serviceName = serviceName;
    }

    public void SendMessageInService(string message)
    {
        Console.WriteLine($"Мессенджер '{_serviceName}': {message}");
        _messenger.SendMessageInService(message);
    }
}