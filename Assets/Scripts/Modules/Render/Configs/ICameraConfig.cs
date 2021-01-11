using Modules.Render.Actors;

namespace Modules.Render.Configs
{
    public interface ICameraConfig
    {
        CameraActor MainCamera { get; }
    }
}