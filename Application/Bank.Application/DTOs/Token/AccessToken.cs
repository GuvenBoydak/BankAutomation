namespace Bank.Application.DTOs.Token;

public class AccessToken
{
    public string Token { get; set; }

    public DateTime Expiration { get; set; }
}