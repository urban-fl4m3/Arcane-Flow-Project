using System;
using UI.Helpers;

namespace UI.Schemes
{
    public interface IViewScheme
    {
        Scheme SchemeType { get; }
        void Init(Action<Scheme> onBehaviourCompleteAction);
        void Execute(Scheme parentBehaviour);
        void Finish();
    }
}