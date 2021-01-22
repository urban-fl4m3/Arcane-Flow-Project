using UnityEngine;

namespace Modules.Datas.Animation
{
    public interface IAnimationData
    {
        Animator GetAnimator();
        string MovingAnimationKey { get; }
        string AttackAnimationKey { get; }
    }
}