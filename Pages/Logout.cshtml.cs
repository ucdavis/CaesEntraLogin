using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaesEntraLogin.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // Sign out from the application
            await HttpContext.SignOutAsync();
            
            // Also sign out from Microsoft Entra ID
            return SignOut(
                new AuthenticationProperties 
                { 
                    RedirectUri = Url.Page("/Index") 
                },
                OpenIdConnectDefaults.AuthenticationScheme
            );
        }
    }
}