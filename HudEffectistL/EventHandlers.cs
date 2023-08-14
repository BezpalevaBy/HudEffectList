using Exiled.API.Features;
using MEC;
using UnityEngine;

namespace HudEffectistL;

public class EventHandlers
{
    private readonly Plugin _plugin;
    public EventHandlers(Plugin plugin) => _plugin = plugin;
    private List<CoroutineHandle> _coroutinetokill = new List<CoroutineHandle>();
    private Dictionary<Player, CoroutineHandle> _playercoroutine = new Dictionary<Player, CoroutineHandle>();
    
    public void OnStartRound()
    {
        _coroutinetokill.Add(MEC.Timing.RunCoroutine(KingCoroutine()));
    }

    public IEnumerator<float> KingCoroutine()
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(1f);

            foreach (Player pl in Player.List)
            {
                if(!pl.IsConnected || !pl.IsAlive) continue;
                
                if(_playercoroutine.TryGetValue(pl, out CoroutineHandle coroutine)) continue;
                
                _playercoroutine.Add(pl, MEC.Timing.RunCoroutine(ShowingEffect(pl)));
            }
        }
    }

    public IEnumerator<float> ShowingEffect(Player player)
    {
        while (true)
        {
            if(!player.IsConnected || !player.IsAlive) yield break;

            string message = "\n \n \n \n \n";

            foreach (var status in player.ActiveEffects)
            {
                message += $"Name:{status.name}; Intensity:{status._intensity}; Time left:{status._timeLeft}                     \n";
            }

            player.ShowHint(message, 1.05f);
            
            yield return Timing.WaitForSeconds(1f);
        }
    }
}