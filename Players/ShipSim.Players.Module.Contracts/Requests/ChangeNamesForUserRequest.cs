using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Requests;

public record ChangeNamesForUserRequest(string FirstName, string LastName) : IRequest<ChangeNamesForUserRequestResult>;

public record ChangeNamesForUserRequestResult(PlayerDto PlayerDto);