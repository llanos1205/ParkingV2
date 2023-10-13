namespace Parking.Contracts.Services;

public interface IAuthService
{
    //interface for authentication
    Task<bool> AuthenticateAsync();  
    Task SignOutAsync();            
    bool IsAuthenticated { get; set; }   
    string GetToken();
    Task<bool> RefreshAsync();

}