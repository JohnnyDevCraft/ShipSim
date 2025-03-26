using MediatR;
using ShipSim.AspireConstants;
using ShipSim.Players.Module.Contracts.Events;
using ShipSim.Ship.Module.Caching;

namespace ShipSim.Ship.Module.EventHandler;

internal class UpdateUserCacheOnUserModifiedEventHandler(ICacheManager cm): INotificationHandler<UserUpdatedEvent>
{
    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        if(await cm.ExistsAsync(string.Format(Defaults.ShipModule.RedisPlayersPrefix, notification.Player.Email)))
        {
            await cm.RemoveAsync(string.Format(Defaults.ShipModule.RedisPlayersPrefix, notification.Player.Email));
            await cm.SetAsync(string.Format(Defaults.ShipModule.RedisPlayersPrefix, notification.Player.Email), notification.Player);
        }
        else
        {
            await cm.SetAsync(string.Format(Defaults.ShipModule.RedisPlayersPrefix, notification.Player.Email), notification.Player);
        }
    }
}