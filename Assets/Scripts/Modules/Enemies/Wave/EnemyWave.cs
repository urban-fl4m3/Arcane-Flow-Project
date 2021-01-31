using System.Collections.Generic;
using Modules.Common;
using UnityEngine;

namespace Modules.Enemies.Wave
{
    [System.Serializable]
    public class EnemyWave
    {
        [SerializeField] private List<ActorGroupComponent> _enemyWaveGroups = new List<ActorGroupComponent>();
        public IReadOnlyList<ActorGroupComponent> EnemyWaveGroups => _enemyWaveGroups;

        public void Add(ActorGroupComponent group)
        {
            _enemyWaveGroups.Add(group);
        }
    }
}