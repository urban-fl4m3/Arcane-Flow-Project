using Modules.Enemies.Wave;

namespace Modules.Enemies.Configs
{
    public interface IAvailableEnemiesConfig
    {
        bool TryGetWave(int waveIndex, out EnemyWave wave);
    }
}