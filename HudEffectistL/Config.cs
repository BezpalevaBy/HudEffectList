using Exiled.API.Interfaces;

namespace HudEffectistL;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = false;
    public bool Debug { get; set; } = false;
}