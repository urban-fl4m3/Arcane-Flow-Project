using UI.Managers;
using UI.Providers;
using UI.Schemes;
using UI.Views.GameHudWindow;
using UI.Views.StartMenuWindow;
using Zenject;

namespace UI.Bindings
{
    public static class SchemeBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<IViewScheme>().To<GameHudScheme>().AsSingle();
            container.Bind<IViewScheme>().To<StartMenuScheme>().AsSingle();

            container.Bind<IViewSchemeProvider>().To<ViewSchemeProvider>().AsSingle();
            container.Bind<IViewSchemeManager>().To<ViewSchemeManager>().AsSingle();
        }
    }
}