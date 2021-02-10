using Modules.Actors;
using Modules.Data.KeyBindings;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Player Cast Behaviour", menuName = "Behaviours/Player/Cast")]
    public class PlayerCastBehaviour : CastBehaviour
    {
        private KeyBindingsData _bindingsData;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);

            _bindingsData = Owner.GetData<KeyBindingsData>();
            
            StartTick();
        }

        protected override void OnTick()
        {
            base.OnTick();
            
            var context 
                = new TransformContext(_caster.SpawnPoint.position, _ownerTransformData.Component.forward);
            
            var activeSpell = GetActiveSpell();
            activeSpell.SpellInput.OnSpellPointDown(context);
            activeSpell.SpellInput.OnSpellHolding(context);
            activeSpell.SpellInput.OnSpellPointUp(context);
            
            if (Input.GetKeyDown(_bindingsData.AttackKey))
            {
                _animationData.Component.SetTrigger(_animationData.AttackAnimationKey);
            }
        }
    }
}