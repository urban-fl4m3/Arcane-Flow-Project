using Modules.Actors;
using Modules.Data.KeyBindings;
using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Player Cast Behaviour", menuName = "Behaviours/Player/Cast")]
    public class PlayerCastBehaviour : CastBehaviour
    {
        private KeyBindingsData _bindingsData;

        private ISpellInput _spellInput;
        
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
            
            _spellInput.OnSpellPointDown(context);
            _spellInput.OnSpellHolding(context);
            _spellInput.OnSpellPointUp(context);
            
            if (Input.GetKeyDown(_bindingsData.AttackKey))
            {
                _animationData.Component.SetTrigger(_animationData.AttackAnimationKey);
            }
        }

        protected override void OnSpellChange(int spellId)
        {
            base.OnSpellChange(spellId);
            _spellInput = _activeSpell.GenerateInputs();
        }
    }
}