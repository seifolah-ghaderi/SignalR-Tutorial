namespace SignalR_Server
{
    public interface INotificationClient
    {
        Task ReceiveMessageFromServer(string message);

        Task ReceiveMessageByTagFromServer(string tag, string message);
    }
}