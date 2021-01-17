﻿using Modules.Actors;
using Modules.Render.Actors;

namespace Modules.Render.Managers
{
    public interface ICameraManager
    {
        CameraActor GameCamera { get; }
        CameraActor UiCamera { get; }
        
        void Init();
        void LoadMainCamera();
        void SetCameraTarget(IActor actor);
    }
}