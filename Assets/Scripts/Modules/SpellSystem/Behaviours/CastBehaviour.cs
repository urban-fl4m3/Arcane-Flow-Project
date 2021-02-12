using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Animation;
using Modules.SpellSystem.Data;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    //Should be an abstract class? 
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        protected SpellData _spellData;
        protected AnimationData _animationData;
        
        private AnimationEventHandlerData _animationEventHandlerData;
        
        protected override void OnInitialize(IActor owner)
        {
            _spellData = Owner.GetData<SpellData>();
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            _animationData = Owner.GetData<AnimationData>();
            
            OnSpellChange(_spellData.ActiveSpellId.Value);

            _animationEventHandlerData.EventHandler.Subscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Subscribe("EndAttackAnimation", AttackAnimationEnd);

            _spellData.ActiveSpellId.PropertyChanged += HandleActiveSpellIdChanged;
        }

        protected override void OnTick()
        {

        }
        
        private void OnSpellChange(int spellId)
        {
            _spellData.ActiveSpell?.Dispose();
            _spellData.ActiveSpell = _spellData.CreateSpell(spellId);
        }
        
        private void HandleActiveSpellIdChanged(object sender, int e)
        {
            OnSpellChange(e);
        }
        

        private void AttackAnimationStart(object sender, EventArgs e)
        {
            _animationData.ApplyRootMotion.Value = _spellData.ActiveSpell.AnimationContext.ApplyRootMotion;
        }
        
        private void AttackAnimationEnd(object sender, EventArgs e)
        {
            _animationData.ApplyRootMotion.ToDefault();
        }


        public override void Dispose()
        {
            _spellData.ActiveSpellId.PropertyChanged -= HandleActiveSpellIdChanged;
            _animationEventHandlerData.EventHandler.Unsubscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Unsubscribe("EndAttackAnimation", AttackAnimationEnd);
            base.Dispose();
        }
    }
}