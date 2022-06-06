using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Megame_support.WebSocket
{
    public class DialogHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
