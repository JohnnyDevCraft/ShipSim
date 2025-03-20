using System;

namespace ShipSim.Race.Module.Contracts.Exceptions;

public class RaceNotFoundByIdException : Exception
{
    public const string ErrorMessage = "ErrorMessage";

    public RaceNotFoundByIdException(params string[] values) : base(string.Format(ErrorMessage, values))
    {
    }
}