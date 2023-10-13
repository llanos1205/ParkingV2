using Parking.Contracts;

namespace Parking.Models;

public class User: ITEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}