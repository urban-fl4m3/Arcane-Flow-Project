using System.Collections.Generic;
using Modules.Actors.Types;
using UnityEngine;

namespace Modules.Enemies.Configs
{
    [System.Serializable]
    public class EnemyWave
    {
        public List<EnemyRoot> _enemyBunchRoots;
    }
    
    [CreateAssetMenu(fileName = "AvailableEnemies", menuName = "Enemies/Available enemies config")]
    public class AvailableEnemiesConfig : ScriptableObject, IAvailableEnemiesConfig
    {
        [SerializeField] private List<EnemyWave> _waves;
        private int _waveNumber = 0;

        public EnemyWave GetAvailableEnemy()
        {
            return _waves[_waveNumber];
        }
    }
}