using System.Collections.Generic;
using Modules.Actors.Types;
using UnityEngine;

namespace Modules.Enemies.Configs
{
    public interface IAvailableEnemiesConfig
    {
        EnemyWave GetAvailableEnemy();
    }
}