namespace ShipSim.Players.Module.Contracts.Exceptions;

public class FailedToCreateUserException(params object?[] values) : Exception(string.Format(ErrorMessage, values))
{
    private const string ErrorMessage = "Failed to create user with Email: {0}";
}