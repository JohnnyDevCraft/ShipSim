using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Requests;

public record GetUserByIdRequest(Guid Id) : IRequest<GetUserByIdRequestResult>;

public record GetUserByIdRequestResult(PlayerDto Player);