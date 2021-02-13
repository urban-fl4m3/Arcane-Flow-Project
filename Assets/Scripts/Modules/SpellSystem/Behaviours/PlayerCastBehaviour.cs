using Modules.Actors;
using Modules.Data.KeyBindings;
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

            if (_spellData.ActiveSpell == null)
            {
                return;
            }
            
            NextSpell();
            PreviousSpell();
            SpellCastStart();
            SpellCastContinue();
            SpellCastEnd();
            SpellCastTick();
        }

        private void NextSpell()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _spellData.ActiveSpellId.Value++;
            }
        }

        private void PreviousSpell()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _spellData.ActiveSpellId.Value--;
            }
        }

        private void SpellCastStart()
        {
            if (Input.GetKeyDown(_bindingsData.AttackKey))
            {
                _spellData.ActiveSpell.OnCastStart();
            }
        }

        private void SpellCastContinue()
        {
            if (Input.GetKey(_bindingsData.AttackKey))
            {
                _spellData.ActiveSpell.OnCastContinue();
            }
        }

        private void SpellCastEnd()
        {
            if (Input.GetKeyUp(_bindingsData.AttackKey))
            {
                _spellData.ActiveSpell.OnCastEnd();
            }
        }

        private void SpellCastTick()
        {
            _spellData.ActiveSpell.OnCastTick();
        }
    }
}