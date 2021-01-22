using Modules.Actors;
using Modules.Render.Actors;

namespace Modules.Render.Managers
{
    public interface ICameraManager
    {
        CameraActor GameCamera { get; }
        
        void Init();
        void InitThirdPersonBehaviours();
        void LoadMainCamera();
        void SetCameraTarget(IActor actor);
    }
}