using Modules.Enemies.Wave;

namespace Modules.Enemies.Factory
{
    public interface IEnemyFactory
    {
        EnemyWave CreateWaveByIndex(int index);
    }
}