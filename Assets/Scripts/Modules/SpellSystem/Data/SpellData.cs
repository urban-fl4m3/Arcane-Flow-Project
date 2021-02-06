using System.Collections.Generic;
using Modules.Actors;
using Modules.Data;
using Modules.SpellSystem.Providers;
using UnityEngine;

namespace Modules.SpellSystem.Data
{
    [CreateAssetMenu(fileName = "Spell Data", menuName = "Data/Spells")]
    public class SpellData : BaseData
    {
        private readonly Dictionary<string, ISpell> _spells = new Dictionary<string, ISpell>();
        private ICaster _caster;
        
        protected override void OnInitialize(IActor owner)
        {
            if (owner is ICaster caster)
            {
                _caster = caster;
            }

            foreach (var spellID in _caster.ListOfSpellsID)
            {
                _spells.Add(spellID, SpellProvider.CreateSpell(spellID));
            }
        }

        public IReadOnlyDictionary<string, ISpell> Spells => _spells;
        
        public void Add(ISpell spell)
        {
            _spells.Add(spell.Id, spell);
        }
    }
}