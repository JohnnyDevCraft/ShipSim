using MediatR;

namespace ShipSim.Players.Module.RequestHandlers;

public record SignInUserRequest(string Email, string Password) : IRequest<SignInUserRequestResult>;

public record SignInUserRequestResult(string AccessToken, string RefreshToken);