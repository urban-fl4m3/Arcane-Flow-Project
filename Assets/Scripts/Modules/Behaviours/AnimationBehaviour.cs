using Modules.Actors;
using Modules.Data.Animation;
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
            _animationData.ApplyRootMotion.PropertyChanged += HandleApplyRootMotionChanged;
            
            OnRootMotionChanged(_animationData.ApplyRootMotion.Value);
        }

        private void HandleApplyRootMotionChanged(object sender, bool value)
        {
            OnRootMotionChanged(value);
        }

        private void OnRootMotionChanged(bool value)
        {
            _animationData.Component.applyRootMotion = value;
        }
        
        public override void Stop()
        {
            base.Stop();
            _animationData.Component.enabled = false;
        }

        public override void Resume()
        {
            base.Resume();
            _animationData.Component.enabled = true;
        }

        public override void Dispose()
        {
            base.Dispose();
            _animationData.ApplyRootMotion.PropertyChanged -= HandleApplyRootMotionChanged;
        }
    }
}