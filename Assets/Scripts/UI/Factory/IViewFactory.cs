using UI.Helpers;
using UI.Views;

namespace UI.Factory
{
    public interface IViewFactory
    {
        BaseView CreateWindow(Window viewType);
    }
}