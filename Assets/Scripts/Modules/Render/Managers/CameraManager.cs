using Modules.Actors;
using Modules.Render.Actors;
using Modules.Render.Configs;
using Modules.Ticks.Managers;
using Object = UnityEngine.Object;

namespace Modules.Render.Managers
{
    public class CameraManager : ICameraManager
    {
        private readonly ICameraConfig _cameraConfig;
        private readonly ITickManager _tickManager;

        private CameraActor _cameraActor;

        public CameraActor CameraActor
        {
            get
            {
                if (_cameraActor == null)
                {
                    LoadCamera();
                }

                return _cameraActor;
            }    
        }
        
        public CameraManager(ICameraConfig cameraConfig, ITickManager tickManager)
        {
            _cameraConfig = cameraConfig;
            _tickManager = tickManager;
        }

        public void Init()
        {
            
        }

        public void SetCameraTarget(IActor actor)
        {
            _cameraActor.FollowActor(actor);
        }

        public void LoadCamera()
        {
            _cameraActor = Object.Instantiate(_cameraConfig.MainCamera);
            _cameraActor.Init(_tickManager.Processor, _cameraActor);
        }
    }
}