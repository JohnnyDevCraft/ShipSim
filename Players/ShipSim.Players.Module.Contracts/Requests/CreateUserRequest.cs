using MediatR;

namespace ShipSim.Players.Module.Contracts.Requests;

public record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password
    ) : IRequest<CreateUserRequestResult>;

public record CreateUserRequestResult(
    Guid UserId
    );