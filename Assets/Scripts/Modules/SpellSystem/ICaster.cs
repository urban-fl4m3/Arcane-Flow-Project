using System.Collections.Generic;
using UnityEngine;

namespace Modules.SpellSystem
{
    public interface ICaster
    {
        List<string> ListOfSpellsID { get; }
        int ActiveSpell { get;  }
        Transform SpawnPoint { get; }
    }
}