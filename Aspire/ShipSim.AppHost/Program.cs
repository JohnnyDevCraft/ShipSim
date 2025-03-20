using ShipSim.AspireConstants;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer(Defaults.SqlServer);
var playerDb = sqlServer.AddDatabase(Defaults.PlayerModule.SqlDb);
var raceDb = sqlServer.AddDatabase(Defaults.RaceModule.RaceDb);

var mongoDb = builder.AddMongoDB(Defaults.MongoDb).WithMongoExpress();
var shipsDb = mongoDb.AddDatabase(Defaults.ShipModule.ShipsDb);

var redisCache = builder.AddRedis(Defaults.RedisCache);




var api = builder.AddProject<Projects.ShipSim_WebApi>(Defaults.WebApi)
    .WithReference(playerDb)
    .WithReference(redisCache)
    .WithReference(shipsDb)
    .WithReference(raceDb)
    .WaitFor(playerDb)
    .WaitFor(redisCache)
    .WaitFor(shipsDb)
    .WaitFor(raceDb);

var migrator = builder.AddProject<Projects.ShipSim_Migrator>(Defaults.Migrator)
    .WithReference(playerDb)
    .WithReference(shipsDb)
    .WithReference(raceDb)
    .WaitFor(playerDb)
    .WaitFor(shipsDb)
    .WaitFor(raceDb);

builder.Build().Run();