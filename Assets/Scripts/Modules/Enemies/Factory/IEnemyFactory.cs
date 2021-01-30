using System;
using System.Collections.Generic;
using Modules.Actors;
using UnityEngine;

namespace Modules.Enemies.Factory
{
    public interface IEnemyFactory
    {
        List<EnemyRoot> CreateEnemy();
    }
}