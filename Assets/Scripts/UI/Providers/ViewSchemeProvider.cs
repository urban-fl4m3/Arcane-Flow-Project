using System;
using System.Collections.Generic;
using System.Linq;
using UI.Helpers;
using UI.Schemes;

namespace UI.Providers
{
    public class ViewSchemeProvider : IViewSchemeProvider
    {
        private readonly Dictionary<Scheme, IViewScheme> _schemes;
        
        public ViewSchemeProvider(List<IViewScheme> schemes)
        {
            if (schemes == null || !schemes.Any())
            {
                throw new ArgumentNullException(nameof(schemes));
            }

            _schemes = schemes.ToDictionary(
                s => s.SchemeType,
                s => s);
        }
        
        public IViewScheme GetScheme(Scheme schemeType)
        {
            if (!_schemes.TryGetValue(schemeType, out var scenario))
            {
                throw new Exception($"There is no scheme with type {schemeType}!");
            }

            return scenario;
        }
    }
}