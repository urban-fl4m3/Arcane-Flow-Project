using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Animation
{
    [CreateAssetMenu(fileName = "New Animation Data", menuName = "Data/Animation")]
    public class AnimationData : BaseData, IAnimationData
    {
        [SerializeField] private string _movingAnimationKey;
        [SerializeField] private string _attackAnimationKey;

        private Animator _animator;

        public Animator GetAnimator()
        {
            return _animator;
        }

        public string MovingAnimationKey => _movingAnimationKey;
        public string AttackAnimationKey => _attackAnimationKey;

        protected override void OnInitialize(IActor owner)
        {
            _animator = owner.GetGameObject().GetComponent<Animator>();
        }
    }
}