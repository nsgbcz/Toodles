using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value;
        public T Value { get => value.Value; set => this.value.Value = value; }
    }
}
