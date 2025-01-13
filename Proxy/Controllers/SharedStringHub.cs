using Microsoft.AspNetCore.SignalR;

public class SharedStringHub : Hub
{
    public async Task SendSharedStringUpdate(string sharedString)
    {
        await Clients.All.SendAsync("ReceiveSharedStringUpdate", sharedString);
    }
}
