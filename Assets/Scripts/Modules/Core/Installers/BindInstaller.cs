﻿using Modules.Core.Bindings;
using Modules.Core.Initializers;
using Modules.Logger.Bindings;
using Modules.Maps.Bindings;
using Modules.Player.Bindings;
using Modules.Render.Bindings;
using Modules.Ticks.Bindings;
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
            PlayerBindings.Bind(Container);
            MapsBindings.Bind(Container);
        }
    }
}