using Parking.Contracts.Services;

namespace Parking.Services;

public sealed class SettingsService:ISettingsService
{
    private const string _baseUrl = "https://localhost:5001";
    private const string _identityEndpoint = "/api/identity";
    private const string _refreshEndpoint = "/api/identity/refresh";
    public string BaseUrl
    {
        get => Preferences.Get(nameof(BaseUrl), _baseUrl);
        set => Preferences.Set(nameof(BaseUrl), value);
    }
    public string IdentityEndpoint 
    {
        get => Preferences.Get(nameof(IdentityEndpoint), _identityEndpoint);
        set => Preferences.Set(nameof(IdentityEndpoint), value);
    }
    public string RefreshEndpoint 
    {
        get => Preferences.Get(nameof(RefreshEndpoint), _refreshEndpoint);
        set => Preferences.Set(nameof(RefreshEndpoint), value);
    }
}