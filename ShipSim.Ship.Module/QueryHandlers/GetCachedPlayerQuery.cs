using MediatR;

namespace ShipSim.Ship.Module.QueryHandlers;

public class ActionHandler(Inject) : IRequestHandler<Action, ActionResult>
{
    public async Task<ActionResult> Handle(Action request, CancellationToken cancellationToken)
    {
        
    }
}