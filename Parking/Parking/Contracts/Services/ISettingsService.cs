namespace Parking.Contracts.Services;

public interface ISettingsService
{
    string BaseUrl { get; set; }
    string IdentityEndpoint { get; set; }
    string RefreshEndpoint { get; set; }
    
}