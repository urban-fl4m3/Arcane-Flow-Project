using Modules.Actors;
using Modules.Player.Configs;
using UnityEngine;

namespace Modules.Player.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayerConfig _playerConfig;

        private Actor _playerActor;
        
        public PlayerManager(IPlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
        }

        public void SpawnPlayer()
        {
            _playerActor = Object.Instantiate(_playerConfig.GetActor());
            _playerActor.Init();
        }
    }
}