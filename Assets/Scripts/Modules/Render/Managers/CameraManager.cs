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

        private int _state = 0;

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
            _gameCamera.Init(_tickManager, _gameCamera.Component);
        }

        public void SetCameraTarget(IActor actor)
        {
            _gameCamera.FollowActor(actor);
        }

        public void LoadMainCamera()
        {
            if (_gameCamera != null) Object.Destroy(_gameCamera.Object);
            _gameCamera = Object.Instantiate(_state == 0 ? _cameraConfig.Camera2D : _cameraConfig.Camera3D);
        }

        public void Stop()
        {
            GameCamera.Stop();
        }

        public void Resume()
        {
            GameCamera.Resume();
        }

        public void SetState(int newState)
        {
            _state = newState;
            LoadMainCamera();
        }
    }
}