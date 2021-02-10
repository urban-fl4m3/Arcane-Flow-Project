using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Animation;
using Modules.SpellSystem.Base;
using Modules.SpellSystem.Data;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    //Should be an abstract class? 
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        protected AnimationData _animationData;
        protected ISpell _activeSpell;
        
        private AnimationEventHandlerData _animationEventHandlerData;
        private SpellData _spellData;
        
        protected override void OnInitialize(IActor owner)
        {
            _spellData = Owner.GetData<SpellData>();
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            _animationData = Owner.GetData<AnimationData>();
            

            OnSpellChange(_spellData.ActiveSpellId);
            
            
            _animationEventHandlerData.EventHandler.Subscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Subscribe("EndAttackAnimation", AttackAnimationEnd);
        }

        protected override void OnTick()
        {

        }
        
        private void OnSpellChange(int spellId)
        {
            _activeSpell = _spellData.GetSpell(spellId);
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
            _animationEventHandlerData.EventHandler.Unsubscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Unsubscribe("EndAttackAnimation", AttackAnimationEnd);
            base.Dispose();
        }
    }
}