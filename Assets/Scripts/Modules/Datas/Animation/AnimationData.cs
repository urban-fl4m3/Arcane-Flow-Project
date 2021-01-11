using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Animation
{
    namespace Datas.TypesOfData.Classes
    {
        [CreateAssetMenu(fileName = "New Animation Data", menuName = "Data/Animation")]
        public class AnimationData : BaseData, IAnimationData
        {
            [SerializeField] private string _movingAnimationKey;
            
            private Animator _animator;

            public Animator GetAnimator()
            {
                return _animator;
            }

            public string MovingAnimationKey => _movingAnimationKey;

            protected override void OnInitialize(IActor owner)
            {
                _animator = owner.GetGameObject().GetComponent<Animator>();
            }
        }
    }
}