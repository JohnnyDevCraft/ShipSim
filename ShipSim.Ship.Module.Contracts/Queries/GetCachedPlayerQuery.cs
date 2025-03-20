using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Ship.Module.Contracts.Queries;

public record GetCachedPlayerQuery(string Email) : IRequest<GetCachedPlayerQueryResult>;

public record GetCachedPlayerQueryResult(PlayerDto Player);