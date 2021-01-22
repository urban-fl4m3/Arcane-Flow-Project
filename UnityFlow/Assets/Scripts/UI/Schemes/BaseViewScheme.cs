using System;
using UI.Helpers;
using UI.Managers;

namespace UI.Schemes
{
    public abstract class BaseViewScheme : IViewScheme
    {
        private Action<Scheme, ISchemeModelMarkup> _onBehaviourComplete;
        
        public abstract Scheme SchemeType { get; }

        protected readonly IViewManager _viewManager;

        protected BaseViewScheme(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        

        public void Execute(ISchemeModelMarkup model, Scheme parentBehaviour)
        {
            Behave(model);
        }

        protected abstract void Behave(ISchemeModelMarkup model);
        
        public virtual void Finish()
        {
            _onBehaviourComplete = null;
        }

        public void Init(Action<Scheme, ISchemeModelMarkup> onBehaviourCompleteAction)
        {
            _onBehaviourComplete = onBehaviourCompleteAction;
        }

        protected void CompleteBehaviour(Scheme nextType, ISchemeModelMarkup model)
        {
            _onBehaviourComplete?.Invoke(nextType, model);
        }
    }
}