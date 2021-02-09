using System;
using UnityEngine;

namespace Modules.SpellSystem.Models
{
    [Serializable]
    public class AnimationContext
    {
        [SerializeField] private bool _applyRootMotion;

        public bool ApplyRootMotion => _applyRootMotion;
    }
}