using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Animation
{
    [CreateAssetMenu(fileName = "New Animation Data", menuName = "Data/Animation")]
    public class AnimationData : BaseData
    {
        [SerializeField] private string _movingAnimationKey;
        [SerializeField] private string _attackAnimationKey;
        [SerializeField] private bool _useRootMotion;

        public Animator Component { get; private set; }
        public string MovingAnimationKey => _movingAnimationKey;
        public string AttackAnimationKey => _attackAnimationKey;
        public bool UseRootMotion => _useRootMotion;

        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<Animator>();
        }
    }
}