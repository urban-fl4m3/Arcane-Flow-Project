using Modules.Actors;
using Modules.AI.Data;
using Modules.Behaviours;
using Modules.Data.Animation;
using Modules.Data.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Behaviours
{
    [CreateAssetMenu(fileName = "Ai Navigation Behaviour", menuName = "Behaviours/Ai Navgation")]
    public class AiNavigationBehaviour : TickBehaviour
    {
        private TransformData _transformData;
        private TransformData _followingTransformData;
        private AnimationData _animationData;
        private AiNavigationData _aiNavigationData;
        
        private NavMeshAgent _navMeshAgent;

        protected override void OnInitialize(IActor owner)
        {
            _aiNavigationData = owner.GetData<AiNavigationData>();
            _transformData = owner.GetData<TransformData>();
            _animationData = owner.GetData<AnimationData>();
            
            _navMeshAgent = _aiNavigationData.NavMeshAgent;
            _aiNavigationData.Player.PropertyChanged += HandleFollowingActorChanged;

            _navMeshAgent.updatePosition = false;
            _navMeshAgent.updateRotation = true;
        }

        protected override void OnTick()
        {
            _navMeshAgent.SetDestination(_followingTransformData.Component.position);
            _navMeshAgent.nextPosition = _transformData.Component.position;

            var reachedTarget = _navMeshAgent.remainingDistance < _aiNavigationData.ReachDistance;
            _animationData.Component.SetBool(_animationData.MovingAnimationKey, !reachedTarget);

            if (reachedTarget)
            {
                _animationData.Component.SetTrigger(_animationData.AttackAnimationKey);
            }
        }

        private void HandleFollowingActorChanged(object sender, IActor actor)
        {
            if (actor != null)
            {
                _followingTransformData = actor.GetData<TransformData>();
                StartTick();
            }
            else
            {
                DisposeTick();
            }
        }
    }
}