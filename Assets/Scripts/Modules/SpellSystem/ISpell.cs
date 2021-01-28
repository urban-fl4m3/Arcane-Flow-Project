using UnityEngine;

namespace Modules.SpellSystem
{
    public interface ISpell
    {
        string Id { get; }
        void Cast(Transform spawnPoint, Vector3 direction);
    }
}