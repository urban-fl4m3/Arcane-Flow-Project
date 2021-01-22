using Modules.Player.Configs;
using Modules.Player.Managers;
using Zenject;

namespace Modules.Player.Bindings
{
    public static class PlayerBindings
    {
        public static void Bind(DiContainer container)
        { 
            container.Bind<IPlayerConfig>().To<PlayerConfig>()
                .FromScriptableObjectResource("Player/MainConfig").AsSingle();
            container.Bind<IPlayerManager>().To<PlayerManager>().AsSingle();
        } 
    }
}