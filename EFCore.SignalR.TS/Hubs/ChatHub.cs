using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EFCore.SignalR.TS.Hubs
{
    public class ChatHub : Hub
    {
        public async Task NewMessage(long username, string message)
        {
            await Clients.All.SendAsync("messageReceived", username, message);
        }
    }
}