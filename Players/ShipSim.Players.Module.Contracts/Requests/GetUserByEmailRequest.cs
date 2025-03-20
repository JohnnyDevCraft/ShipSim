using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Requests;

public record GetUserByEmailRequest(string Email) : IRequest<GetUserByEmailRequestResult>;

public record GetUserByEmailRequestResult(PlayerDto Player);