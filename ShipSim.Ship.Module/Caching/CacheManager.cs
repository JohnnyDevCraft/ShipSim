using System.Text.Json;
using StackExchange.Redis;

namespace ShipSim.Ship.Module.Caching;

internal class CacheManager(IConnectionMultiplexer connectionMultiplexer): ICacheManager
{
    private readonly IDatabase _db = connectionMultiplexer.GetDatabase();
    
    public async Task<T?> GetAsync<T>(string keyFormatter, string key)
    {
        var result = await _db.StringGetAsync(string.Format(keyFormatter, key));
        var finalResult =  result.HasValue ? JsonSerializer.Deserialize<T>(result) : default;
        
        return finalResult;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var valueToStore = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, valueToStore, expiration);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        var result = await _db.KeyDeleteAsync(key);
        return result;
    }

    public async Task<bool> ExistsAsync(string key)
    {
        var result =await _db.KeyExistsAsync(key);
        return result;
    }

    public async Task ClearAsync()
    {
        await _db.ExecuteAsync("FLUSHDB");
        return;
    }
}