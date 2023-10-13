using System.Text;
using Newtonsoft.Json;
using Parking.Contracts.Services;
using Parking.Models;

namespace Parking.Services;
public class RefreshCredentials
{
    public string RefreshToken { get; set; }
}
public class ApiAuthService:IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ISettingsService _settingsService;
    private string _accessToken;
    private string _refreshToken;
    private AuthCredentials _credentials;
    
    public ApiAuthService(HttpClient httpClient , ISettingsService settingsService)
    {
        _httpClient = httpClient;
        _settingsService = settingsService;
    }
 
    
    public async Task<bool> AuthenticateAsync()
    {
        var url = $"{_settingsService.BaseUrl}{_settingsService.IdentityEndpoint}";
        //call the login endpoint by http and store the access and refresh tokens
        var authContent = new StringContent(JsonConvert.SerializeObject(_credentials), Encoding.UTF8, "application/json");
        var authResult = await _httpClient.PostAsync(url, authContent);
        if (authResult.IsSuccessStatusCode)
        {
            var authResultContent = await authResult.Content.ReadAsStringAsync();
            var authResultData = JsonConvert.DeserializeObject<AuthResult>(authResultContent);
            _accessToken = authResultData.AccessToken;
            _refreshToken = authResultData.RefreshToken;
            _credentials = null;
            this.IsAuthenticated = true;
            return true;
        }
        _credentials = null;
        return false;
    }

    public  Task SignOutAsync()
    {
        _accessToken = string.Empty;
        _refreshToken = string.Empty;
        _credentials = null;
        this.IsAuthenticated = false;
        return Task.CompletedTask;
        
    }

    public bool IsAuthenticated { get; set; }
    public string GetToken()
    {
        return _accessToken;
    }

    public async Task<bool> RefreshAsync()
    {
        // get a new set of tokens using the refresh token 
        var url = $"{_settingsService.BaseUrl}{_settingsService.RefreshEndpoint}";
        var refreshContent = new StringContent(JsonConvert.SerializeObject(new RefreshCredentials(){RefreshToken = _refreshToken}), Encoding.UTF8, "application/json");
        var refreshResult = await _httpClient.PostAsync(url, refreshContent);
        if (refreshResult.IsSuccessStatusCode)
        {
            var refreshResultContent = refreshResult.Content.ReadAsStringAsync().Result;
            var refreshResultData = JsonConvert.DeserializeObject<AuthResult>(refreshResultContent);
            _accessToken = refreshResultData.AccessToken;
            _refreshToken = refreshResultData.RefreshToken;
            IsAuthenticated = true;
            return true;
        }
        IsAuthenticated = false;
        return false;
    }
}

