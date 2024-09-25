using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace signalrfiledownloaddotnetcore;
[Authorize]
public class FileDownloadHub : Hub
{

    public async Task NotifyDownloadReady(string userId, string fileUrl)
    {
        await Clients.User(userId).SendAsync("DownloadReady", fileUrl);
    }





}
