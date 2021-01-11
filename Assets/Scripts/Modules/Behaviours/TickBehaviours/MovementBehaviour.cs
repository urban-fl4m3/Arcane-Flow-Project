using Modules.Actors;
using Modules.Datas.Animation;
using Modules.Datas.Animation.Datas.TypesOfData.Classes;
using Modules.Datas.KeyBindings;
using Modules.Datas.Movement;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Movement Behaviour", menuName = "Behaviours/Movement")]
    public class MovementBehaviour: TickBehaviour
    {
        private IAnimationData _animationData;
        private IMovementData _movementData;
        private IKeyBindingsData _bindingData;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _animationData = Owner.GetData<AnimationData>();
            _movementData = Owner.GetData<MovementData>();
            _bindingData = Owner.GetData<KeyBindingsData>();
        }
        
        public override void Tick()
        {
            var isMoving = _bindingData.IsMovementButtonHolding();
            _movementData.MovementAxis = _bindingData.GetMovementAxis();
            _movementData.IsMoving = isMoving;
            _animationData.GetAnimator().SetBool(_animationData.MovingAnimationKey, isMoving);
        }
    }
}