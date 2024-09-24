using System.Security.Claims;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace signalrfiledownloaddotnetcore.Pages
{
    [Authorize]
    public class FileDownloadModel : PageModel
    {

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            BackgroundJob.Enqueue(() => ProcessFile(emailClaim));
            TempData["notification"] = "File download process will be start soon";
            return Redirect("/HomePage");
        }



        public async Task ProcessFile(string userId)
        {
            await Task.Delay(6000); // Simulate file processing
            string fileUrl = "example.png";
            var rr = new FileDownloadHub();



            await rr.NotifyDownloadReady(userId, fileUrl);

        }
    }
}
