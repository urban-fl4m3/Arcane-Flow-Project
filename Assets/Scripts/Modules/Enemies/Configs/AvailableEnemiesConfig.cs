using System.Collections.Generic;
using Modules.Enemies.Wave;
using UnityEngine;

namespace Modules.Enemies.Configs
{
    [CreateAssetMenu(fileName = "AvailableEnemies", menuName = "Enemies/Available enemies config")]
    public class AvailableEnemiesConfig : ScriptableObject, IAvailableEnemiesConfig
    {
        [SerializeField] private List<EnemyWave> _waves;

        public bool TryGetWave(int waveIndex, out EnemyWave wave)
        {
            wave = null;
            if (waveIndex < 0 || waveIndex >= _waves.Count)
            {
                return false;
            }

            wave = _waves[waveIndex];
            return true;
        }
    }
}