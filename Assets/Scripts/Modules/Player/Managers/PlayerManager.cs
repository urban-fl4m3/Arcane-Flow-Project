using System;
using Modules.Actors;
using Modules.Maps.Managers;
using Modules.Player.Configs;
using Modules.Ticks.Managers;
using Object = UnityEngine.Object;

namespace Modules.Player.Managers
{
    public class PlayerManager : IPlayerManager
    {
        public event EventHandler<IActor> PlayerActorSpawned;
        
        private readonly IPlayerConfig _playerConfig;
        private readonly IMapManager _mapManager;
        private readonly ITickManager _tickManager;

        private Actor _playerActor;
        
        public PlayerManager(IPlayerConfig playerConfig, IMapManager mapManager, ITickManager tickManager)
        {
            _playerConfig = playerConfig;
            _mapManager = mapManager;
            _tickManager = tickManager;
        }

        public void Init()
        {
            _mapManager.OnMapLoaded += HandleMapLoaded;
        }

        private void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init(_tickManager.Processor);
            
            PlayerActorSpawned?.Invoke(this, _playerActor);
        }

        private void HandleMapLoaded(object sender, EventArgs e)
        {
            SpawnPlayer();
        }
    }
}