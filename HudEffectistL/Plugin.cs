using Exiled.API.Features;
using Exiled.Events;

namespace HudEffectistL;

public class Plugin : Plugin<Config>
{
    public override string Name => "HudEffectList";
    public override string Prefix => "HudEL";
    public override string Author => "Starlight/Bezpa";

    private EventHandlers _handlers;
    
    public override void OnEnabled()
    {
        Exiled.Events.Handlers.Server.RoundStarted += _handlers.OnStartRound;
        
        _handlers = new EventHandlers(this);
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= _handlers.OnStartRound;
        
        _handlers = null;
        base.OnDisabled();
    }
}