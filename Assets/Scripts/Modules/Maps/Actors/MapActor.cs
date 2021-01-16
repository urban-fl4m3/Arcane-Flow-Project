using System.Collections.Generic;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.AI.Data;
using Modules.Datas.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Maps.Actors
{
    public class MapActor : ActorBase, IMapActor
    {
        [SerializeField] private NavMeshData _navMeshData;
        [SerializeField] private List<Transform> _spawnPoints;

        private IActor _player;
        
        protected override void OnAwake()
        {
            
            base.OnAwake();
        }

        public void AddPlayer(IActor player)
        {
            _player = player;
        }

        public void AddEnemy(IActor enemy)
        {
            enemy.GetData<TransformData>().GetTransform().position = _spawnPoints[0].position;
            enemy.GetData<AiNavigationData>().NavMeshData = _navMeshData;
            enemy.GetData<AiNavigationData>().Player = _player;
        }
    }
}