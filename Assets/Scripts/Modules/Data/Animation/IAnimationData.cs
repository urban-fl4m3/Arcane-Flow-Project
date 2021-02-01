using UnityEngine;

namespace Modules.Data.Animation
{
    public interface IAnimationData
    {
        Animator Component { get; }
        string MovingAnimationKey { get; }
        string AttackAnimationKey { get; }
    }
}