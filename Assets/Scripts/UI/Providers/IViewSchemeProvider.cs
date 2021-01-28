using UI.Helpers;
using UI.Schemes;

namespace UI.Providers
{
    public interface IViewSchemeProvider
    {
        IViewScheme GetScheme(Scheme schemeType);
    }
}