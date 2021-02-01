using System.Collections;
using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Enum;
using UnityEngine;

public class AoeSpell : ISpell
{
    private readonly string _id;
    private readonly SpellType _type;
    private readonly ActorBase _actor;
    private readonly IEnumerable<Tag> _tags;

    public AoeSpell(string id, SpellType type, ActorBase actor, IEnumerable<Tag> tags)
    {
        _id = id;
        _type = type;
        _actor = actor;
        _tags = tags;
    }

    public string Id => _id;
        
    public void Cast(Transform spawnPoint, Vector3 direction)
    {
        var spellInstance = Object.Instantiate(_actor, spawnPoint.position + direction * 5.0f, Quaternion.identity);
    }
}
