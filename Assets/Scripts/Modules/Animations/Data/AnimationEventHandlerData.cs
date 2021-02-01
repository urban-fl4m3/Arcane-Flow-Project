using Modules.Actors;
using Modules.Data;
using UnityEngine;

namespace Modules.Animations.Data
{
    [CreateAssetMenu(fileName = "Animation Event Handler Data", menuName = "Data/Animation Event Handler")]
    public class AnimationEventHandlerData : BaseData
    {
        public IAnimationEventHandler EventHandler { get; private set; }
        
        protected override void OnInitialize(IActor owner)
        {
            EventHandler = owner.GetGameObject().GetComponent<AnimationEventHandler>();
        }
    }
}