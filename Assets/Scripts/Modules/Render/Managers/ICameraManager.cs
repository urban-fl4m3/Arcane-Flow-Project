using Modules.Render.Actors;

namespace Modules.Render.Managers
{
    public interface ICameraManager
    {
        CameraActor CameraActor { get; }
        
        void Init();
        void LoadCamera();
    }
}