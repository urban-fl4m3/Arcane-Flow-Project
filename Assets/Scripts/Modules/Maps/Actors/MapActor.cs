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

        private readonly List<AiNavigationData> _aiNavigationData = new List<AiNavigationData>();
        
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
            aiNavigationData.Player.Value = _player.Value;
            _aiNavigationData.Add(aiNavigationData);
            
            _player.PropertyChanged += aiNavigationData.HandlePlayerChanged;
        }

        public void Dispose()
        {
            foreach (var aiNavigationData in _aiNavigationData)
            {
                _player.PropertyChanged -= aiNavigationData.HandlePlayerChanged;
            }
            
            _aiNavigationData.Clear();
        }

        private void OnDestroy()
        {
            NavMesh.RemoveNavMeshData(_navMeshDataInstance);
        }
    }
}