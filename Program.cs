using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();

// Configure OpenID Connect options to add domain hint
builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.Events = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProvider = context =>
        {
            // Add domain hint to redirect to UC Davis login
            context.ProtocolMessage.DomainHint = "ucdavis.edu";
            
            // Optional: Add login hint with a specific user format
            // context.ProtocolMessage.LoginHint = "user@ucdavis.edu";
            
            // Optional: Force re-authentication
            // context.ProtocolMessage.Prompt = "login";
            
            // Optional: Set specific scopes
            // context.ProtocolMessage.Scope = "openid profile email";
            
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Welcome");
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
