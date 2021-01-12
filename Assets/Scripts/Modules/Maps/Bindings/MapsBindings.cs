using Modules.Maps.Configs;
using Modules.Maps.Managers;
using Modules.Maps.Providers;
using Zenject;

namespace Modules.Maps.Bindings
{
    public static class MapsBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<IAvailableLightningsConfig>().To<AvailableLightningsConfig>()
                .FromScriptableObjectResource("Maps/AvailableLightnings").AsSingle();
            container.Bind<IAvailableMapsConfig>().To<AvailableMapsConfig>()
                .FromScriptableObjectResource("Maps/AvailableMaps").AsSingle();

            container.Bind<IMapSettingsProvider>().To<MapSettingsProvider>().AsSingle();
            container.Bind<IMapManager>().To<MapManager>().AsSingle();
        }
    }
}