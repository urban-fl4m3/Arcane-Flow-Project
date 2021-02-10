using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Animation;
using Modules.Data.Transforms;
using Modules.SpellSystem.Base;
using Modules.SpellSystem.Data;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    //Should be an abstract class? 
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        protected AnimationData _animationData;
        protected TransformData _ownerTransformData;

        protected ISpell _activeSpell;
        protected ICaster _caster;
        
        private AnimationEventHandlerData _animationEventHandlerData;
        private SpellData _spellData;
        
        protected override void OnInitialize(IActor owner)
        {
            _spellData = Owner.GetData<SpellData>();
            _ownerTransformData = Owner.GetData<TransformData>();
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            _animationData = Owner.GetData<AnimationData>();
            
            if (owner is ICaster caster)
            {
                _caster = caster;
            }

            OnSpellChange( _caster.ActiveSpell);
            
            _animationEventHandlerData.EventHandler.Subscribe("Cast", Cast);
            
            _animationEventHandlerData.EventHandler.Subscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Subscribe("EndAttackAnimation", AttackAnimationEnd);
        }

        protected override void OnTick()
        {

        }

        private void Cast(object sender, EventArgs e)
        {
            // activeSpell.Cast(context);
            
            var context 
                = new TransformContext(_caster.SpawnPoint.position, _ownerTransformData.Component.forward);
            _activeSpell.Cast(context);
        }
        
        protected virtual void OnSpellChange(int spellId)
        {
            var activeSpellId = _caster.ListOfSpellsID[spellId];
            _activeSpell = _spellData.Spells[activeSpellId];
        }

        private void AttackAnimationStart(object sender, EventArgs e)
        {
            _animationData.ApplyRootMotion.Value = _activeSpell.AnimationContext.ApplyRootMotion;
        }
        
        private void AttackAnimationEnd(object sender, EventArgs e)
        {
            _animationData.ApplyRootMotion.ToDefault();
        }


        public override void Dispose()
        {
            _animationEventHandlerData.EventHandler.Unsubscribe("Cast", Cast);
            
            _animationEventHandlerData.EventHandler.Unsubscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Unsubscribe("EndAttackAnimation", AttackAnimationEnd);
            base.Dispose();
        }
    }
}