using System.Collections.Generic;
using Modules.Behaviours;
using Modules.Render.Actors;

namespace Modules.Render.Configs
{
    public interface ICameraConfig
    {
        CameraActor MainCamera { get; }
        IReadOnlyList<BaseBehaviour> GameSceneBaseBehaviours { get; }
    }
}