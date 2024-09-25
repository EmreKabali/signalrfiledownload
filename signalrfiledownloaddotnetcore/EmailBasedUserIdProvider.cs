using System;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace signalrfiledownloaddotnetcore;

public class EmailBasedUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        // Kullanıcının email claim'ini alıyoruz
        return connection.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    }
}
