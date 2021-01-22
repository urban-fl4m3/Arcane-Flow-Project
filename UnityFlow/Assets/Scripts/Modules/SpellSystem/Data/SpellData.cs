using System.Collections.Generic;
using Modules.Actors;
using Modules.Datas;
using UnityEngine;

namespace Modules.SpellSystem.Data
{
    [CreateAssetMenu(fileName = "Spell Data", menuName = "Data/Spells")]
    public class SpellData : BaseData, ISpellData
    {
        private readonly Dictionary<string, ISpell> _spells = new Dictionary<string, ISpell>();
        
        protected override void OnInitialize(IActor owner)
        {
            
        }

        public IReadOnlyDictionary<string, ISpell> Spells => _spells;
        
        public void Add(ISpell spell)
        {
            _spells.Add(spell.Id, spell);
        }
    }
}