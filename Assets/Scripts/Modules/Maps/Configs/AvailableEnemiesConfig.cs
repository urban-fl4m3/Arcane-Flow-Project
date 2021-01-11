using Modules.Actors.Types;
using UnityEngine;

namespace Modules.Maps.Configs
{
    [CreateAssetMenu(fileName = "AvailableEnemies", menuName = "Maps/Available enemies config")]
    public class AvailableEnemiesConfig : ScriptableObject, IAvailableEnemiesConfig
    {
        [SerializeField] private ActorBase _dummy;

        public ActorBase GetAvailableEnemy()
        {
            return _dummy;
        }
    }
}