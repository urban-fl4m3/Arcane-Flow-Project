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

        private CameraActor _gameCamera;

        public CameraActor GameCamera
        {
            get
            {
                if (_gameCamera == null)
                {
                    LoadMainCamera();
                }

                return _gameCamera;
            }    
        }
        
        public CameraManager(ICameraConfig cameraConfig, ITickManager tickManager)
        {
            _cameraConfig = cameraConfig;
            _tickManager = tickManager;
        }

        public void Init()
        {
            _gameCamera.Init(_tickManager.Processor, _gameCamera);
        }

        public void InitThirdPersonBehaviours()
        {
            foreach (var behaviour in _cameraConfig.GameSceneBaseBehaviours)
            {
                _gameCamera.AddBehaviour(behaviour);
            }   
        }

        public void SetCameraTarget(IActor actor)
        {
            _gameCamera.FollowActor(actor);
        }

        public void LoadMainCamera()
        {
            _gameCamera = Object.Instantiate(_cameraConfig.MainCamera);
        }
    }
}