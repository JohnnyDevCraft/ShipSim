using MediatR;

namespace ShipSim.Players.Module.Contracts.Requests;

public record SignInUserRequest(string Email, string Password) : IRequest<SignInUserRequestResult>;

public record SignInUserRequestResult(string AccessToken, string RefreshToken);