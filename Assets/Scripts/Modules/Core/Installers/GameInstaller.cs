using Modules.Core.Initializers;
using Zenject;

namespace Modules.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameInitializer>().To<GameInitializer>().AsSingle();
        }

        public override void Start()
        {
            var gameInitializer = Container.Resolve<IGameInitializer>();
            gameInitializer.PrepareInitializationCommands();
            gameInitializer.Run();
        }
    }
}