using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class Value<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        T value;

        public Value(T value)// : this()
        {
            this.value = value;
        }

        T IVar<T>.Value { get => value; set => this.value = value; }
        T IGet<T>.Value { get => value; }
        T ISet<T>.Value { set => this.value = value; }
    }
}
