using CoffeeSpace.Client.Contracts.Authentication;
using CoffeeSpace.Client.Services.Abstractions;
using CoffeeSpace.Client.WebApiClients;
using Microsoft.IdentityModel.Tokens;
using SecureStorage = Xamarin.Essentials.SecureStorage;


namespace CoffeeSpace.Client.Services;

public sealed class AuthService : IAuthService
{
    private readonly IIdentityWebApi _identityWebApi;

    public AuthService(IIdentityWebApi identityWebApi)
    {
        _identityWebApi = identityWebApi;
    }

    public async Task<bool> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var token = await _identityWebApi.LoginAsync(request, cancellationToken);
        if (token.IsNullOrEmpty())
        {
            return false;
        }
        
        await SecureStorage.SetAsync("jwt-token", token);
        return true;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var token = await _identityWebApi.RegisterAsync(request, cancellationToken);
        if (token.IsNullOrEmpty())
        {
            return false;
        }

        await SecureStorage.SetAsync("jwt-token", token);
        return true;
    }
}