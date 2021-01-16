using Modules.Actors;

namespace Modules.Common
{
    public class DynamicActor : DynamicProperty<IActor>
    {
        private IActor _actor;

        protected override IActor DynamicValue
        {
            get => _actor; 
            set => _actor = value;
        }
        
        protected override bool Equals(IActor lhs, IActor rhs)
        {
            return lhs == rhs;
        }
    }
}