using System;
using UI.Helpers;

namespace UI.Schemes
{
    public interface IViewScheme
    {
        Scheme SchemeType { get; }
        void Init(Action<Scheme, ISchemeModelMarkup> onBehaviourCompleteAction);
        void Execute(ISchemeModelMarkup model, Scheme parentBehaviour);
        void Finish();
    }
}