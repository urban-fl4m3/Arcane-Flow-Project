using Modules.Actors;
using Modules.Maps.Managers;
using Modules.Player.Configs;
using Modules.Render.Managers;
using Modules.SpellSystem.Data;
using Modules.Ticks.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.Player.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayerConfig _playerConfig;
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;

        private Actor _playerActor;

        public IActor PlayerActor => _playerActor;

        public PlayerManager()
        {
            var world = World.CurrentInstance;
            
            _playerConfig = world.Settings.PlayerConfig;
            _tickManager = world.ResolveManager<ITickManager>();
            _cameraManager = world.ResolveManager<ICameraManager>();
        }

        public void Init() { }

        public void Stop()
        {
            _playerActor.Stop();
        }

        public void Resume()
        {
            _playerActor.Resume();
        }

        public void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init(_tickManager, _cameraManager.GameCamera);
            _cameraManager.SetCameraTarget(_playerActor);
        }

        public void RemovePlayer()
        {
            _cameraManager.GameCamera.StopFollowing();
            _playerActor.DestroyActor();
            _playerActor = null;
        }
    }
}