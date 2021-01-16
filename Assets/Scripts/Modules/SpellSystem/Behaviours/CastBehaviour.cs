using System;
using Modules.Actors;
using Modules.Animations;
using Modules.Animations.Data;
using Modules.Behaviours;
using Modules.Behaviours.TickBehaviours;
using Modules.Datas.Animation;
using Modules.Datas.KeyBindings;
using Modules.Datas.Transforms;
using Modules.SpellSystem.Data;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        private Animator _animator;

        private IAnimationData _animationData;
        private IKeyBindingsData _bindingData;
        private ISpellData _spellData;
        private ITransformData _ownerTransformData;
        private AnimationEventHandlerData _animationEventHandlerData;

        private ICaster _caster;
        
        protected override void OnInitialize(IActor owner)
        {
            _animationData = Owner.GetData<AnimationData>();
            _animator = _animationData.GetAnimator();
            _bindingData = Owner.GetData<KeyBindingsData>();
            _spellData = Owner.GetData<SpellData>();
            _ownerTransformData = Owner.GetData<TransformData>();
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            
            if (owner is ICaster caster)
            {
                _caster = caster;
            }

            _animationEventHandlerData.EventHandler.AddEvent("Cast", Cast);
            base.OnInitialize(owner);

        }

        public override void Tick()
        {
            if (Input.GetKeyDown(_bindingData.GetAttackKey()))
            {
                _animator.SetTrigger(_animationData.AttackAnimationKey);
            }
        }

        private void Cast(object sender, EventArgs e)
        {
            var activeSpell = _spellData.Spells[_caster.Id];
            activeSpell.Cast(_caster.SpawnPoint, _ownerTransformData.GetTransform().forward);
        }
    }
}