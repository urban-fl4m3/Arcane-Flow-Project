using Modules.Actors;
using Modules.AI.Data;
using Modules.Behaviours;
using Modules.Datas.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Behaviours
{
    [CreateAssetMenu(fileName = "Ai Navigation Behaviour", menuName = "Behaviours/Ai Navgation")]
    public class AiNavigationBehaviour : TickBehaviour
    {
        private AiNavigationData _aiNavigationData;

        private NavMeshDataInstance _navMeshDataInstance;
        
        protected override void OnInitialize(IActor owner)
        {
            _aiNavigationData = owner.GetData<AiNavigationData>();
            
            base.OnInitialize(owner);
        }

        public override void Tick()
        {
            var navMeshData = _aiNavigationData.NavMeshData;
            var player = _aiNavigationData.Player;
            
            if (navMeshData != null && player != null)
            {
                _navMeshDataInstance = NavMesh.AddNavMeshData(navMeshData);
                    
                var navMeshAgent = _aiNavigationData.NavMeshAgent;
                
                navMeshAgent.SetDestination(player.GetData<TransformData>().GetTransform().position);
            }
        }
    }
}