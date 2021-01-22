using UnityEngine;

namespace Modules.SpellSystem
{
    public interface ICaster
    {
        string Id { get; }
        Transform SpawnPoint { get; }
    }
}