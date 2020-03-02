using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class Var<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value;

        public Var(IVar<T> value)// : this()
        {
            this.value = value;
        }

        public T Value { get => value.Value; set => this.value.Value = value; }
    }
}
