using System.Collections.Generic;
using UI.Factory;
using UI.Helpers;
using UI.Views;

namespace UI.Managers
{
    public class ViewManager : IViewManager
    {
        private readonly Dictionary<Window, BaseView> _instancedViews 
            = new Dictionary<Window, BaseView>();
        
        private readonly IViewFactory _viewFactory;
        
        public ViewManager(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public void AddView(Window type, ICustomModel model, bool activate = false)
        {
            var hasInstance = _instancedViews.TryGetValue(type, out var view);

            if (!hasInstance)
            {
                view = _viewFactory.CreateWindow(type);
                _instancedViews.Add(type, view);
            }
            
            view.gameObject.SetActive(activate);
            view.Initialize(model);
        }

        public void CloseView(Window type)
        {
            var hasInstance = _instancedViews.TryGetValue(type, out var view);

            if (hasInstance)
            {
                view.CloseView();    
            }
        }
    }
}