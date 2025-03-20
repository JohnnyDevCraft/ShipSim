namespace ShipSim.AspireConstants;

public static class Defaults
{
    public const string WebApi = "WebApi";
    public const string SqlServer = "SqlServer";
    public const string Migrator = nameof(Migrator);
    public const string RedisCache = nameof(RedisCache);
    public const string MongoDb = "mongo";
    
    
    
    public static class PlayerModule
    {
        public const string SqlDb = "playersDb";
    }
    
    public static class ShipModule
    {
        public const string ShipsDb = "shipsdb";
        public const string ShipsCollection = "ships";
        public const string ShipTypesCollection = "ship-types";
        
        public const string RedisPlayersPrefix = "Ships:Players:{0}";
        public const string RedisRacesPrefix = "Ships:Races:{0}";
    }
    
    public static class RaceModule
    {
        public const string RaceDb = "racedb";
    }
}