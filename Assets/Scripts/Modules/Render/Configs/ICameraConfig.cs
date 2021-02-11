using System.Collections.Generic;
using Modules.Behaviours;
using Modules.Render.Actors;

namespace Modules.Render.Configs
{
    public interface ICameraConfig
    {
        CameraActor Camera2D { get; }
        CameraActor Camera3D { get; }
        IReadOnlyList<BaseBehaviour> GameSceneBaseBehaviours { get; }
    }
}