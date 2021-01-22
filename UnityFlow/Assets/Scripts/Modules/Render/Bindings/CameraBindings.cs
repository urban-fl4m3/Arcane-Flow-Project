using Modules.Render.Configs;
using Modules.Render.Managers;
using Zenject;

namespace Modules.Render.Bindings
{
    public static class CameraBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<ICameraConfig>().To<CameraConfig>()
                .FromScriptableObjectResource("Render/CameraConfig").AsSingle();
            container.Bind<ICameraManager>().To<CameraManager>().AsSingle();
        }
    }
}