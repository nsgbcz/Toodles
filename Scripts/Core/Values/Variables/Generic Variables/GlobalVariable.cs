using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value = new Val<T>();
        public T Value { get => value.Value; set => this.value.Value = value; }
    }
}
