using UI.Data;
using UI.Factory;
using UI.Managers;
using Zenject;

namespace UI.Bindings
{
    public static class UiBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<CanvasContainer>().FromScriptableObjectResource("UI/CanvasContainer").AsSingle();
            container.Bind<ViewsContainer>().FromScriptableObjectResource("UI/ViewsContainer").AsSingle();
            container.Bind<IViewManager>().To<ViewManager>().AsSingle();
            container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
        }
    }
}