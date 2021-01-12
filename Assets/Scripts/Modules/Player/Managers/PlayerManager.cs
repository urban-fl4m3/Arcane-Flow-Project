using System;
using Modules.Actors;
using Modules.Maps.Managers;
using Modules.Player.Configs;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using Object = UnityEngine.Object;

namespace Modules.Player.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayerConfig _playerConfig;
        private readonly IMapManager _mapManager;
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;

        private Actor _playerActor;
        
        public PlayerManager(IPlayerConfig playerConfig, IMapManager mapManager, ITickManager tickManager,
            ICameraManager cameraManager)
        {
            _playerConfig = playerConfig;
            _mapManager = mapManager;
            _tickManager = tickManager;
            _cameraManager = cameraManager;
        }

        public void Init()
        {
            _mapManager.OnMapLoaded += HandleMapLoaded;
        }

        private void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init(_tickManager.Processor, _cameraManager.CameraActor);
            _cameraManager.SetCameraTarget(_playerActor);
        }

        private void HandleMapLoaded(object sender, EventArgs e)
        {
            SpawnPlayer();
        }
    }
}