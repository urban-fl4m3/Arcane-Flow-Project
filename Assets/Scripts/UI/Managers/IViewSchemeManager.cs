using UI.Helpers;
using UI.Schemes;

namespace UI.Managers
{
    public interface IViewSchemeManager
    {
        IViewScheme CurrentScheme { get; }

        void AddScheme(Scheme type);
        void CompleteScheme(Scheme nextBehaviourType);
    }
}