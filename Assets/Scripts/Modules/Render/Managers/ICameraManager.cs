﻿using Modules.Actors;
using Modules.Core.Managers;
using Modules.Render.Actors;

namespace Modules.Render.Managers
{
    public interface ICameraManager : IManager
    {
        CameraActor GameCamera { get; }
        
        void InitThirdPersonBehaviours();
        void LoadMainCamera();
        void SetCameraTarget(IActor actor);
        
    }
}