using System;

namespace ShipSim.Core.Exceptions;

public class UserUnauthenticatedException() : Exception(ErrorMessage)
{
    private const string ErrorMessage = "There is no Authenticated User";
}