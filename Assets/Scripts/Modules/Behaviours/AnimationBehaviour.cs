using Modules.Actors;
using Modules.Datas.Animation;
using UnityEngine;

namespace Modules.Behaviours
{
    [CreateAssetMenu(fileName = "New Animation Behaviour", menuName = "Behaviours/AnimationController")]
    public class AnimationBehaviour : BaseBehaviour
    {
        private AnimationData _animationData;
        protected override void OnInitialize(IActor owner)
        {
            _animationData = owner.GetData<AnimationData>();
        }

        public override void Stop()
        {
            base.Stop();
            _animationData.GetAnimator().enabled = false;
        }

        public override void Resume()
        {
            base.Resume();
            _animationData.GetAnimator().enabled = true;
        }
    }
}