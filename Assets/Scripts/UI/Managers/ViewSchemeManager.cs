using System;
using System.Collections.Generic;
using System.Linq;
using UI.Helpers;
using UI.Providers;
using UI.Schemes;

namespace UI.Managers
{
    public class ViewSchemeManager : IViewSchemeManager
    { 
         private readonly IViewSchemeProvider _provider;
        private readonly Stack<IViewScheme> _activeSchemes = new Stack<IViewScheme>();

        public IViewScheme CurrentScheme => _activeSchemes.Any() ? _activeSchemes.Peek() : null;
        
        public ViewSchemeManager(IViewSchemeProvider schemeProvider)
        {
            _provider = schemeProvider;
        }

        public void AddScheme(Scheme type)
        {
            var currentSchemeType = CurrentScheme?.SchemeType ?? Scheme.Unknown;
			
            var scenarioInStack = _activeSchemes
                .FirstOrDefault(s => s.SchemeType == type);
            
            if (scenarioInStack != null)
            {
                throw new Exception($"Behaviour '{type}' is already added!");
            }

            var newScheme = _provider.GetScheme(type);
            newScheme.Init(CompleteScheme);
            _activeSchemes.Push(newScheme);
            CurrentScheme?.Execute(currentSchemeType);
        }

        public void CompleteScheme(Scheme nextBehaviourType)
        {
            CompleteBehaviourInternal(nextBehaviourType);
        }
        
        private void CompleteBehaviourInternal(Scheme nextSchemeType)
        {
            var currentSchemeType = CurrentScheme.SchemeType;
			
            CurrentScheme.Finish();
            _activeSchemes.Pop();

            if (nextSchemeType != Scheme.Unknown)
            {
                var schemeInStack = _activeSchemes
                    .FirstOrDefault(s => s.SchemeType == nextSchemeType);
                if (schemeInStack != null)
                {
                    if (schemeInStack != _activeSchemes.Peek())
                    {
                        throw new Exception("Wrong next scheme type!");
                    }
                }
                else
                {
                    var nextBehaviour = _provider.GetScheme(nextSchemeType);
                    nextBehaviour.Init(CompleteScheme);
                    _activeSchemes.Push(nextBehaviour);
                    CurrentScheme.Execute(currentSchemeType);

                    return;
                }
            }
			
            throw new Exception("There is no active schemes!");
        }

    }
}