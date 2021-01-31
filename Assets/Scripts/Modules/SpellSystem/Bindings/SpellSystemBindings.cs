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
            container.Bind<SpellPreset>()
                .FromScriptableObjectResource("Spells").AsTransient();

            container.Bind<ISpellProvider>().To<SpellProvider>().AsSingle();
            container.Bind<ISpellManager>().To<SpellManager>().AsSingle();
        }
    }
}