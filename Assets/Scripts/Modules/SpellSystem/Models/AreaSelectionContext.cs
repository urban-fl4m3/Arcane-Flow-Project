using System;
using UnityEngine;

namespace Modules.SpellSystem.Models
{
    [Serializable]
    public class AreaSelectionContext
    {
        [SerializeField] private Sprite _selectionSprite;

        public Sprite SelectionSprite => _selectionSprite;
    }
}