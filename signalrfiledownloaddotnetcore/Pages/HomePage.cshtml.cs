using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace signalrfiledownloaddotnetcore.Pages
{
    [Authorize]
    public class HomePageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
