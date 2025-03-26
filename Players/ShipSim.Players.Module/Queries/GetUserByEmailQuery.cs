using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Queries;

public record GetUserByEmailQuery(string Email) : IRequest<GetUserByEmailQueryResult>;

public record GetUserByEmailQueryResult(PlayerDto? PlayerDto);