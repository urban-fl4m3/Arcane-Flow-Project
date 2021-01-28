using System.Collections.Generic;
using Modules.Common;

namespace Modules.Datas.Attributes
{
    public interface IAttributesData
    {
        IReadOnlyDictionary<Attribute, DynamicFloat> Attributes { get; }
    }
}