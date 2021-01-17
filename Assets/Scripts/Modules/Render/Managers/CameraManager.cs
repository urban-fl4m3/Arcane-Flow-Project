using Modules.Actors;
using Modules.Render.Actors;
using Modules.Render.Configs;
using Modules.Ticks.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.Render.Managers
{
    public class CameraManager : ICameraManager
    {
        private readonly ICameraConfig _cameraConfig;
        private readonly ITickManager _tickManager;

        private CameraActor _gameCamera;
        private CameraActor _uiCamera;

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

        public CameraActor UiCamera
        {
            get
            {
                if (_uiCamera == null)
                {
                    LoadUiCamera();
                }

                return _uiCamera;
            }
        }
        
        public CameraManager(ICameraConfig cameraConfig, ITickManager tickManager)
        {
            _cameraConfig = cameraConfig;
            _tickManager = tickManager;
        }

        public void Init()
        {
           // LoadMainCamera();
        }

        public void SetCameraTarget(IActor actor)
        {
            _gameCamera.FollowActor(actor);
        }

        public void LoadMainCamera()
        {
            _gameCamera = Object.Instantiate(_cameraConfig.MainCamera);
            _gameCamera.Init(_tickManager.Processor, _gameCamera);
          //  _gameCamera.Component.clearFlags = CameraClearFlags.Depth;
        }
        
        public void LoadUiCamera()
        {
            _uiCamera = Object.Instantiate(_cameraConfig.UICamera);
            _uiCamera.Init(_tickManager.Processor, _uiCamera);
            _uiCamera.Component.clearFlags = CameraClearFlags.Depth;
        }
    }
}