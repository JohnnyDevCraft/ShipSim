using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Commands;

public record ChangeNamesForUserCommand(string FirstName, string LastName, string Email) : IRequest<ChangeNamesForUserCommandResult>;

public record ChangeNamesForUserCommandResult(PlayerDto Player);