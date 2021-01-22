using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Managers;
using Modules.SpellSystem.Providers;
using Zenject;

namespace Modules.SpellSystem.Bindings
{
    public static class SpellSystemBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<ISpellContainer>().To<SpellContainer>()
                .FromScriptableObjectResource("Spells/SpellContainer").AsSingle();

            container.Bind<ISpellProvider>().To<SpellProvider>().AsSingle();
            container.Bind<ISpellManager>().To<SpellManager>().AsSingle();
        }
    }
}