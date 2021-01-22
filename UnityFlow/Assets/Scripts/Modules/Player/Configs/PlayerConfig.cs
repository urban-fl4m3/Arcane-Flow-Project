using Modules.Actors;
using UnityEngine;

namespace Modules.Player.Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Player/Main Config")]
    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [SerializeField] private Actor _playerActor;

        public Actor GetActor()
        {
            return _playerActor;
        }
    }
}