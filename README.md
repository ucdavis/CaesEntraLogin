# CaesEntraLogin - Microsoft Entra Authentication Demo

A demonstration ASP.NET Core Razor Pages application showcasing Microsoft Entra ID authentication using client secret authentication.

## Features

- Microsoft Entra ID authentication with OpenID Connect
- Client secret-based authentication (suitable for server-side applications)
- Protected pages requiring authentication
- User profile information display
- Login/logout functionality
- Responsive Bootstrap UI

## Prerequisites

- .NET 8.0 SDK
- Microsoft Entra ID tenant
- Registered application in Microsoft Entra ID

## Azure App Registration Setup

1. **Register your application in Microsoft Entra ID:**
   - Go to the [Azure Portal](https://portal.azure.com)
   - Navigate to Microsoft Entra ID > App registrations
   - Click "New registration"
   - Enter application name (e.g., "CaesEntraLogin")
   - Select "Accounts in this organizational directory only" (single tenant)
   - Set Redirect URI to: `https://localhost:7000/signin-oidc` (Web platform)
   - Click "Register"

2. **Configure authentication:**
   - In your app registration, go to "Authentication"
   - Add additional redirect URI if needed: `https://localhost:5001/signin-oidc`
   - Enable "ID tokens" under Implicit grant and hybrid flows
   - Configure logout URL: `https://localhost:7000/signout-oidc`

3. **Create a client secret:**
   - Go to "Certificates & secrets"
   - Click "New client secret"
   - Add description and select expiration
   - Copy the secret value (you won't be able to see it again)

4. **Note down the following values:**
   - Application (client) ID
   - Directory (tenant) ID
   - Client secret value

## Configuration

Update the `appsettings.json` file with your Microsoft Entra ID application details:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "[Your-Tenant-ID]",
    "ClientId": "[Your-Client-ID]",
    "ClientSecret": "[Your-Client-Secret]",
    "CallbackPath": "/signin-oidc"
  }
}
```

**Security Note:** For production applications, store the client secret in:
- Azure Key Vault
- Environment variables
- User secrets (for development)

To use user secrets for development:
```bash
dotnet user-secrets set "AzureAd:ClientSecret" "your-secret-here"
```

## Running the Application

1. **Clone or download the project**
2. **Configure the application** as described above
3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
4. **Run the application:**
   ```bash
   dotnet run
   ```
5. **Navigate to:** `https://localhost:7000` or `http://localhost:5000`

## Application Flow

1. **Home Page:** Shows different content based on authentication status
2. **Login Page:** Provides a login button that redirects to Microsoft Entra ID
3. **Authentication:** Users authenticate with their Microsoft credentials
4. **Welcome Page:** Protected page showing user information after successful login
5. **Logout:** Users can sign out and return to the home page

## Project Structure

- `Program.cs` - Application configuration and Microsoft Identity Web setup
- `Pages/Login.cshtml` - Login page with Microsoft sign-in button
- `Pages/Welcome.cshtml` - Protected page showing user information
- `Pages/Shared/_Layout.cshtml` - Navigation with authentication-aware menu
- `appsettings.json` - Configuration including Azure AD settings

## Dependencies

- **Microsoft.Identity.Web (3.3.1)** - Microsoft Identity platform integration
- **ASP.NET Core 8.0** - Web framework
- **Bootstrap 5** - UI framework

## Security Features

- OpenID Connect authentication flow
- Protected routes requiring authentication
- Secure token handling
- Automatic token refresh
- HTTPS enforcement

## Troubleshooting

1. **Invalid redirect URI:** Ensure the redirect URI in Azure AD matches your application URL
2. **Client secret issues:** Verify the secret is correct and hasn't expired
3. **Tenant/Application ID:** Double-check these values in the Azure portal
4. **HTTPS requirements:** Microsoft Entra ID requires HTTPS for authentication

## Further Reading

- [Microsoft Identity Web documentation](https://docs.microsoft.com/en-us/azure/active-directory/develop/microsoft-identity-web)
- [ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)
- [Microsoft Entra ID documentation](https://docs.microsoft.com/en-us/azure/active-directory/)

## License

This project is licensed under the MIT License - see the LICENSE file for details.