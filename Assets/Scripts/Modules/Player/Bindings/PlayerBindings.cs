using Modules.Player.Configs;
using Zenject;

namespace Modules.Player.Bindings
{
    public static class PlayerBindings
    {
        public static void Bind(DiContainer container)
        { 
            container.Bind<IPlayerConfig>().To<PlayerConfig>()
                .FromScriptableObjectResource("Player/MainConfig").AsSingle();
        } 
    }
}