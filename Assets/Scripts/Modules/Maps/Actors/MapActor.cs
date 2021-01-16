using System;
using System.Collections.Generic;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.AI.Data;
using Modules.Common;
using Modules.Datas.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Maps.Actors
{
    public class MapActor : ActorBase, IMapActor
    {
        [SerializeField] private NavMeshData _navMeshData;
        [SerializeField] private List<Transform> _spawnPoints;

        private readonly DynamicActor _player = new DynamicActor();
        private NavMeshDataInstance _navMeshDataInstance;
        
        protected override void OnAwake()
        {
            _navMeshDataInstance = NavMesh.AddNavMeshData(_navMeshData);
            
            base.OnAwake();
        }

        public void AddPlayer(IActor player)
        {
            _player.Value = player;
        }

        public void AddEnemy(IActor enemy)
        {
            enemy.GetData<TransformData>().GetTransform().position = _spawnPoints[0].position;
            var aiNavigationData = enemy.GetData<AiNavigationData>();
            aiNavigationData.Player = _player;

            _player.PropertyChanged += aiNavigationData.HandlePlayerChanged;
        }

        private void OnDestroy()
        {
            NavMesh.RemoveNavMeshData(_navMeshDataInstance);
        }
    }
}