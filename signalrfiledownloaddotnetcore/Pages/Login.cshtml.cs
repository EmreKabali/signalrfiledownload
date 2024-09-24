using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace signalrfiledownloaddotnetcore.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            var claims = new List<Claim>
{
    new Claim(ClaimTypes.Email, Email),
    new Claim(ClaimTypes.Name, "Osman"),
     new Claim("FullName","Kabalı" ),
        new Claim("Number", "555"),
};

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(10),
                });
            return Redirect("/HomePage");
        }


        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
    }



}

