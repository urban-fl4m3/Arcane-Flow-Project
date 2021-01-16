using Modules.Actors;
using Modules.AI.Data;
using Modules.Behaviours;
using Modules.Datas.Animation;
using Modules.Datas.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Behaviours
{
    [CreateAssetMenu(fileName = "Ai Navigation Behaviour", menuName = "Behaviours/Ai Navgation")]
    public class AiNavigationBehaviour : TickBehaviour
    {
        private ITransformData _transformData;
        private IAnimationData _animationData;
        private AiNavigationData _aiNavigationData;
        
        private NavMeshAgent _navMeshAgent;
        private IActor _followActor;

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

        public override void Tick()
        {
            _navMeshAgent.SetDestination(_followActor.GetData<TransformData>().GetTransform().position);
            _navMeshAgent.nextPosition = _transformData.GetTransform().position;

            var reachedTarget = _navMeshAgent.remainingDistance < _aiNavigationData.ReachDistance;
            _animationData.GetAnimator().SetBool(_animationData.MovingAnimationKey, !reachedTarget);
        }

        private void HandleFollowingActorChanged(object sender, IActor actor)
        {
            _followActor = actor;

            if (actor != null)
            {
                StartTick();
            }
            else
            {
                StopTick();
            }
        }
    }
}