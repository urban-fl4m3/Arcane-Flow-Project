using Modules.Actors.Types;
using UnityEngine;

namespace Modules.Enemies.Configs
{
    [CreateAssetMenu(fileName = "AvailableEnemies", menuName = "Enemies/Available enemies config")]
    public class AvailableEnemiesConfig : ScriptableObject, IAvailableEnemiesConfig
    {
        [SerializeField] private ActorBase _dummy;

        public ActorBase GetAvailableEnemy()
        {
            return _dummy;
        }
    }
}