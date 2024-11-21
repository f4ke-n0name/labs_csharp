namespace Itmo.ObjectOrientedProgramming.Lab3.MessangerLib;

public class Messanger : IMessanger
{
    private readonly string _serviceName;
    private readonly IMessanger _messanger;

    public Messanger(IMessanger messanger, string serviceName)
    {
        _messanger = messanger;
        _serviceName = serviceName;
    }

    public void SendMessageInService(string message)
    {
        Console.WriteLine($"Мессенджер '{_serviceName}': {message}");
        _messanger.SendMessageInService(message);
    }
}