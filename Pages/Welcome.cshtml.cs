using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CaesEntraLogin.Pages
{
    [Authorize]
    public class WelcomeModel : PageModel
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserId { get; set; }

        public void OnGet()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                UserName = User.FindFirstValue("name") ?? "Unknown User";
                UserEmail = User.FindFirstValue(ClaimTypes.Email) ?? User.FindFirstValue("preferred_username") ?? "N/A";
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "N/A";
            }
        }
    }
}