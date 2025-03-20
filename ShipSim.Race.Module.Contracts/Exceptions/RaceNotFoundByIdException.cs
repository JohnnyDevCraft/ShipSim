using System;

namespace ShipSim.Race.Module.Contracts.Exceptions;

public class RaceNotFoundByIdException(params object?[] values) : Exception(string.Format(ErrorMessage, values))
{
    private const string ErrorMessage = "The Race with Id {0} was not found.";
}