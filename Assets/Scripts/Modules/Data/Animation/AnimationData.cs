using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Animation
{
    [CreateAssetMenu(fileName = "New Animation Data", menuName = "Data/Animation")]
    public class AnimationData : BaseData, IAnimationData
    {
        [SerializeField] private string _movingAnimationKey;
        [SerializeField] private string _attackAnimationKey;

        public Animator Component { get; private set; }
        public string MovingAnimationKey => _movingAnimationKey;
        public string AttackAnimationKey => _attackAnimationKey;

        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<Animator>();
        }
    }
}