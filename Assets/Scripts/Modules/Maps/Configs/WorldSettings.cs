using Modules.Actors.Types;
using Modules.Enemies.Configs;
using Modules.Maps.Actors;
using Modules.Player.Configs;
using UnityEngine;

namespace Modules.Maps.Configs
{
    [CreateAssetMenu(fileName = "New World Settings", menuName = "World/Settings")]
    public class WorldSettings : ScriptableObject
    {
        [SerializeField] private MapActor _map;
        [SerializeField] private ActorBase _lightning;

        [SerializeField] private PlayerConfig _playerConfig;
        
        [SerializeField] private bool _withEnemies;
        [SerializeField] private AvailableEnemiesConfig _availableEnemies;

        public PlayerConfig PlayerConfig => _playerConfig;

        public bool WithEnemies => _withEnemies;
        public AvailableEnemiesConfig AvailableEnemies => _availableEnemies;

        public MapActor Map => _map;
        public ActorBase Lightning => _lightning;
    }
}