using System.Collections.Generic;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.AI.Data;
using Modules.Common;
using Modules.Enemies.Wave;
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
        private int _enemyGroupNumber;

        private readonly List<AiNavigationData> _aiNavigationData = new List<AiNavigationData>();
        
        protected override void OnAwake()
        {
            _navMeshDataInstance = NavMesh.AddNavMeshData(_navMeshData);
            _enemyGroupNumber = 0;
            base.OnAwake();
        }

        public void AddPlayer(IActor player)
        {
            _player.Value = player;
        }

        public void AddWave(EnemyWave wave)
        {
            foreach (var enemyRoot in wave.EnemyWaveGroups)
            {
                enemyRoot.GetComponent<Transform>().position = _spawnPoints[_enemyGroupNumber % _spawnPoints.Count].position;

                foreach (var enemy in enemyRoot.Actors)
                {
                    var aiNavigationData = enemy.GetData<AiNavigationData>();
                    aiNavigationData.Player.Value = _player.Value;
                    _aiNavigationData.Add(aiNavigationData);
            
                    _player.PropertyChanged += aiNavigationData.HandlePlayerChanged;
                }
                
                _enemyGroupNumber++;
            }
        }

        public void Dispose()
        {
            foreach (var aiNavigationData in _aiNavigationData)
            {
                _player.PropertyChanged -= aiNavigationData.HandlePlayerChanged;
            }

            _enemyGroupNumber = 0;
            _aiNavigationData.Clear();
        }

        private void OnDestroy()
        {
            NavMesh.RemoveNavMeshData(_navMeshDataInstance);
        }
    }
}