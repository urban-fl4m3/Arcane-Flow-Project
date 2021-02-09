using Modules.Actors;
using Modules.Common;
using UnityEngine;

namespace Modules.Data.Animation
{
    [CreateAssetMenu(fileName = "New Animation Data", menuName = "Data/Animation")]
    public class AnimationData : BaseData
    {
        [SerializeField] private string _movingAnimationKey;
        [SerializeField] private string _attackAnimationKey;
        [SerializeField] private DynamicBool applyRootMotion;

        public Animator Component { get; private set; }
        public string MovingAnimationKey => _movingAnimationKey;
        public string AttackAnimationKey => _attackAnimationKey;
        public DynamicBool ApplyRootMotion => applyRootMotion;

        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<Animator>();
        }
    }
}