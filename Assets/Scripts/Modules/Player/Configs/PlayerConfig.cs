using Modules.Actors;
using UnityEngine;

namespace Modules.Player.Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Player/Main Config")]
    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [SerializeField] private Actor _playerActor2D;
        [SerializeField] private Actor _playerActor3D;

        public Actor GetActor(int index)
        {
            return index == 0 ? _playerActor2D : _playerActor3D;
        }
    }
}