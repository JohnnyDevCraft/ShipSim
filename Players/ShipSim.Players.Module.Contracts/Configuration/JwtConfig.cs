namespace ShipSim.Players.Module.Contracts.Configuration;

public class JwtConfig
{
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int ExpiryInMinutes { get; set; }
    public int RefreshTokenExpiryInHours { get; set; }
    
}
