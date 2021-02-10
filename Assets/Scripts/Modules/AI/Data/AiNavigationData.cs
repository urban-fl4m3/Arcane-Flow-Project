using Modules.Actors;
using Modules.Common;
using Modules.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Data
{
    [CreateAssetMenu(fileName = "Nav Mesh Data", menuName = "Data/Nav Mesh")]
    public class AiNavigationData : BaseData
    {
        [SerializeField] private float _reachDistance;

        protected override void OnInitialize(IActor owner)
        {
            NavMeshAgent = owner.Object.GetComponent<NavMeshAgent>();
            Player = new DynamicActor();
        }

        public void HandlePlayerChanged(object sender, IActor actor)
        {
            Player.Value = actor;
        }
        
        public float DistanceToTarget { get; set; }
        public DynamicActor Player { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }

        public float ReachDistance => _reachDistance;
    }
}