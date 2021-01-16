using Modules.Actors;
using Modules.AI.Data;
using Modules.Behaviours;
using Modules.Datas.Transforms;
using UnityEngine;

namespace Modules.AI.Behaviours
{
    [CreateAssetMenu(fileName = "Ai Navigation Behaviour", menuName = "Behaviours/Ai Navgation")]
    public class AiNavigationBehaviour : TickBehaviour
    {
        private AiNavigationData _aiNavigationData;

        private IActor _followActor;
        
        protected override void OnInitialize(IActor owner)
        {
            _aiNavigationData = owner.GetData<AiNavigationData>();
            _aiNavigationData.Player.PropertyChanged += HandleFollowingActorChanged;
        }

        public override void Tick()
        {
            var navMeshAgent = _aiNavigationData.NavMeshAgent;
            navMeshAgent.SetDestination(_followActor.GetData<TransformData>().GetTransform().position);
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