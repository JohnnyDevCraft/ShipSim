namespace ShipSim.Ship.Module.Caching;

internal interface ICacheManager
{
    Task<T?> GetAsync<T>(string keyFormatter, string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task<bool> RemoveAsync(string key);
    Task<bool> ExistsAsync(string key);
    Task ClearAsync();
}