using Modules.Enemies.Configs;
using Modules.Enemies.Factory;
using Modules.Enemies.Managers;
using Modules.Enemies.Providers;
using Zenject;

namespace Modules.Enemies.Bindings
{
    public static class EnemyBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<IAvailableEnemiesConfig>().To<AvailableEnemiesConfig>()
                .FromScriptableObjectResource("Enemies/AvailableEnemies").AsSingle();

            container.Bind<IEnemyProvider>().To<EnemyProvider>().AsSingle();
            container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            container.Bind<IEnemyManager>().To<EnemyManager>().AsSingle();
        }
    }
}