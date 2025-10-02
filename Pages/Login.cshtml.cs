using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaesEntraLogin.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            // If user is already authenticated, redirect to Welcome page
            if (User.Identity?.IsAuthenticated == true)
            {
                Response.Redirect("/Welcome");
            }
        }

        public IActionResult OnPostSignIn()
        {
            var redirectUrl = Url.Page("/Welcome");
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}