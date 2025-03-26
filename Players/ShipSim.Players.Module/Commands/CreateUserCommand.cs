using MediatR;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Commands;

public record CreateUserCommand(PlayerDto Player, string Password) : IRequest<CreateUserCommandResult>;

public record CreateUserCommandResult(PlayerDto Player);