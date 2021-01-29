using Modules.Actors;
using Modules.Common;
using Modules.Datas;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Data
{
    [CreateAssetMenu(fileName = "Nav Mesh Data", menuName = "Data/Nav Mesh")]
    public class AiNavigationData : BaseData
    {
        [SerializeField] private float _reachDistance;
        
        public DynamicActor Player { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }

        public float ReachDistance => _reachDistance;

        protected override void OnInitialize(IActor owner)
        {
            NavMeshAgent = owner.GetGameObject().GetComponent<NavMeshAgent>();
            Player = new DynamicActor();
        }

        public void HandlePlayerChanged(object sender, IActor actor)
        {
            Player.Value = actor;
        }
    }
}