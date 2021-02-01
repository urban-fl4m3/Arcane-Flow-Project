using System.Collections.Generic;
using Modules.Common;

namespace Modules.Data.Attributes
{
    public interface IAttributesData
    {
        IReadOnlyDictionary<Attribute, DynamicFloat> Attributes { get; }
    }
}