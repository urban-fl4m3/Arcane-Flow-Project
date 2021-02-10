using Modules.SpellSystem.Models;

namespace Modules.SpellSystem.Inputs
{
    public interface ISpellInput
    {
        void OnSpellPointDown(TransformContext context);
        void OnSpellHolding(TransformContext context);
        void OnSpellPointUp(TransformContext context);
    }
}