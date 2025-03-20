using System;

namespace ShipSim.Players.Module.Contracts.Exceptions;

public class UserByEmailNotFoundException(params object?[] values) : Exception(string.Format(ErrorMessage, values))
{
    private const string ErrorMessage = "Unable to locate user with email: {0}";
}