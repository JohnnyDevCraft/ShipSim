using System;

namespace ShipSim.Players.Module.Contracts.Exceptions;

public class UserWithEmailAlreadyExistsException(params object?[] values)
    : Exception(string.Format(ErrorMessage, values))
{
    private const string ErrorMessage = "A user with the provided email already exists: {0}";
}