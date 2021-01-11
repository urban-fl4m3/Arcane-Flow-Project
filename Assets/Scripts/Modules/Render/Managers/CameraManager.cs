using System;
using Modules.Actors;
using Modules.Player.Managers;
using Modules.Render.Actors;
using Modules.Render.Configs;
using Modules.Ticks.Managers;
using Object = UnityEngine.Object;

namespace Modules.Render.Managers
{
    public class CameraManager : ICameraManager
    {
        private readonly ICameraConfig _cameraConfig;
        private readonly IPlayerManager _playerManager;
        private readonly ITickManager _tickManager;

        private CameraActor _cameraActor;
        
        public CameraManager(ICameraConfig cameraConfig, IPlayerManager playerManager, ITickManager tickManager)
        {
            _cameraConfig = cameraConfig;
            _playerManager = playerManager;
            _tickManager = tickManager;
        }

        public void Init()
        {
            _playerManager.PlayerActorSpawned += HandlePlayerActorSpawned;
        }

        private void HandlePlayerActorSpawned(object sender, IActor actor)
        {
            _cameraActor.FollowActor(actor);
        }

        public void LoadCamera()
        {
            _cameraActor = Object.Instantiate(_cameraConfig.MainCamera);
            _cameraActor.Init(_tickManager.Processor);
        }
    }
}