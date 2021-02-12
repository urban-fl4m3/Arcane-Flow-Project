using Modules.Actors;

namespace Modules.Common
{
    public class DynamicActor : DynamicProperty<IActor>
    {
        protected override IActor DynamicValue { get; set; }

        protected override bool Equals(IActor lhs, IActor rhs)
        {
            return lhs == rhs;
        }
    }
}