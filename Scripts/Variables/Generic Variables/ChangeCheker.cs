using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    using Iterables;
    public class ChangeCheker<T> : IVar<T>
    {
        [AssetSelector]
        [SerializeField, Required]
        IAction OnValueChange;
        [SerializeField, Required]
        IVar<T> value;

        public T Value
        {
            get => value.Value;
            set
            {
                if (this.value.Value.Equals(value)) return;
                this.value.Value = value;
                OnValueChange?.Action();
            }
        }
    }
}
