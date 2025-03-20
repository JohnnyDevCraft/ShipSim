using MediatR;

namespace ShipSim.Race.Module;

public class ActionHandler(Inject) : IRequestHandler<Action, ActionResult>
{
    public async Task<ActionResult> Handle(Action request, CancellationToken cancellationToken)
    {
        
    }
}