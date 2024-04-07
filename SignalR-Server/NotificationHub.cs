using Microsoft.AspNetCore.SignalR;

namespace SignalR_Server
{
    public sealed class NotificationHub : Hub
    {
        /// <summary>
        /// this function be clled when the default message sent to server:
        /// </summary>
        /// <example>
        ///{"protocol":"json","version":1}
        /// </example>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("receiveMessageFromServer", $"new client", $"{this.Context.ConnectionId}");
            Console.WriteLine($"Conneected {this.Context.ConnectionId}");
        }

        /// <summary>
        /// thi method called from client
        /// </summary>
        /// <param name="message">this will be arguments in json message</param>
        /// <example>
        ///{"arguments":["this is seifolah"],"target":"CallMe","type":1}
        /// </example>
        /// <returns></returns>
        public async Task CallMe(string message)
        {
            await this.Clients.All.SendAsync("receiveMessageFromServer", "call from client", $"{Context.ConnectionId}:{message}♥");
        }
    }
}