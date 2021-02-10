using Modules.Actors;
using Modules.AI.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Ai Cast Behaviour", menuName = "Behaviours/AI/Cast")]
    public class AiCastBehaviour : CastBehaviour
    {
        private AiNavigationData _aiNavigationData;
        private NavMeshAgent _navMeshAgent;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);

            _aiNavigationData = Owner.GetData<AiNavigationData>();
            _navMeshAgent = _aiNavigationData.NavMeshAgent;
        }

        protected override void OnTick()
        {
            base.OnTick();
            
            var reachedTarget = _navMeshAgent.remainingDistance < _aiNavigationData.ReachDistance;

            if (reachedTarget)
            {
                _animationData.Component.SetTrigger(_animationData.AttackAnimationKey);
            }
        }
    }
}