using Exiled.API.Interfaces;

namespace HudEffectistL;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = false;
    public bool Debug { get; set; } = false;
    public float Intensity { get; set; } = 1f;
    public ushort textSize { get; set; } = 10;
}