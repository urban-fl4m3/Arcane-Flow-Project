using System;

namespace Modules.Common
{
    public abstract class DynamicProperty<T>
    {
        protected abstract T DynamicValue { get; set; }
        
        public T Value
        {
            get
            {
                return DynamicValue;
            }
            set
            {
                var isEquals = Equals(DynamicValue, value);

                if (isEquals)
                {
                    return;
                }
                
                DynamicValue = value;
                PropertyChanged?.Invoke(this, DynamicValue);
            }
        }

        protected abstract bool Equals(T lhs, T rhs);

        public event EventHandler<T> PropertyChanged;
    }
}