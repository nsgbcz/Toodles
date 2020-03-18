using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public class Val<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        T value;
        public Val() { }
        public Val(T value)// : this()
        {
            this.value = value;
        }

        public T Value { get => value; set => this.value = value; }
    }
}
