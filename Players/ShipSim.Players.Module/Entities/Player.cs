using Microsoft.AspNetCore.Identity;

namespace ShipSim.Players.Module.Entities;

internal class Player: IdentityUser<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}