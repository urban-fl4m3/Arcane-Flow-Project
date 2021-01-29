using Modules.Core.Bindings;
using Modules.Core.Initializers;
using Modules.Logger.Bindings;
using Modules.Player.Bindings;
using Modules.Render.Bindings;
using Modules.SpellSystem.Bindings;
using Modules.Ticks.Bindings;
using UI.Bindings;
using Zenject;

namespace Modules.Core.Installers
{
    public class BindInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneInitializer>().AsSingle();
            
            InitializationBindings.Bind(Container);
            TicksBinding.Bind(Container);
            LoggerBindings.Bind(Container);
            CameraBindings.Bind(Container);
            SpellSystemBindings.Bind(Container);
            PlayerBindings.Bind(Container);
            UiBindings.Bind(Container);
            SchemeBindings.Bind(Container);
        }
    }
}