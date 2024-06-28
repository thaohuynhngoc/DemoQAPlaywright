namespace DemoQAFramework.Models;

public class TokenResponse
{
    public string? UserId {get;set;}
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
    public DateTime Expires {get;set;}
    public DateTime Created_Date {get;set;}
    public bool IsActive { get; set; }
}