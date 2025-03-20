using MediatR;

namespace ShipSim.Race.Module.RequestHandlers;

public class ActionHandler(Inject) : IRequestHandler<Action, ActionResult>
{
    public async Task<ActionResult> Handle(Action request, CancellationToken cancellationToken)
    {
        
    }
}