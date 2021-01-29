using System;
using UI.Helpers;
using UI.Managers;

namespace UI.Schemes
{
    public abstract class BaseViewScheme : IViewScheme
    {
        private Action<Scheme> _onBehaviourComplete;
        
        public abstract Scheme SchemeType { get; }

        protected readonly IViewManager _viewManager;

        protected BaseViewScheme(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        

        public void Execute(Scheme parentBehaviour)
        {
            Behave();
        }

        protected abstract void Behave();
        
        public virtual void Finish()
        {
            _onBehaviourComplete = null;
        }

        public void Init(Action<Scheme> onBehaviourCompleteAction)
        {
            _onBehaviourComplete = onBehaviourCompleteAction;
        }

        protected void CompleteBehaviour(Scheme nextType)
        {
            _onBehaviourComplete?.Invoke(nextType);
        }
    }
}