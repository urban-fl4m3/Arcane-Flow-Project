﻿using System.Collections.Generic;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem
{
    public class Spell : ISpell
    {
        private readonly string _id;
        private readonly SpellType _type;
        private readonly SpellActor _actor;
        private readonly IEnumerable<Tag> _tags;

        public Spell(string id, SpellType type, SpellActor actor, IEnumerable<Tag> tags)
        {
            _id = id;
            _type = type;
            _actor = actor;
            _tags = tags;
        }

        public string Id => _id;
        
        public void Cast(Transform spawnPoint, Vector3 direction)
        {
            var spellInstance = Object.Instantiate(_actor, spawnPoint.position, Quaternion.identity);
            spellInstance.Direction = direction;
        }
    }
}