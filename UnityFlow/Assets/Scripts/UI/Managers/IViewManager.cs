using UI.Helpers;

namespace UI.Managers
{
    public interface IViewManager
    {
        void AddView(Window type, ICustomModel model, bool activate = true);
        void CloseView(Window type);
    }
}