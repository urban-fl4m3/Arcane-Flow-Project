using System.Collections.Generic;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.Datas.Transforms;
using UnityEngine;

namespace Modules.Maps.Actors
{
    public class MapActor : ActorBase, IMapActor
    {
        [SerializeField] private List<Transform> _spawnPoints;
        
        protected override void OnAwake()
        {
            
            base.OnAwake();
        }

        public void AddEnemy(IActor enemy)
        {
            enemy.GetData<TransformData>().GetTransform().position = _spawnPoints[0].position;
        }
    }
}