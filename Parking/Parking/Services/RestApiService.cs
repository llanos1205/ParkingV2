using Parking.Contracts.Services;

namespace Parking.Services;

public class RestApiService
{
    private readonly IAuthService _authenticationService;
    private readonly HttpClient _httpClient;
    public RestApiService(IAuthService authenticationService, HttpClient httpClient)
    {
        _authenticationService = authenticationService;
        _httpClient = httpClient;
    }
}