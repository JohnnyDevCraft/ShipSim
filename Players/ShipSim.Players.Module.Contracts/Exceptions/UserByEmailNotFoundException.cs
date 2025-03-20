using System;

namespace ShipSim.Players.Module.Contracts.Exceptions;

public class UserByEmailNotFoundException : Exception
{
    public const string ErrorMessage = "ErrorMessage";

    public UserByEmailNotFoundException(params string[] values) : base(string.Format(ErrorMessage, values))
    {
    }
}