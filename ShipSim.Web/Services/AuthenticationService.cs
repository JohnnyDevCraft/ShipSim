using System.Reactive.Subjects;

namespace ShipSim.Web.Services;

public class AuthenticationService
{
    private readonly BehaviorSubject<bool> _isAuthenticated = new(false);
    public IObservable<bool> IsAuthenticated => _isAuthenticated;
}