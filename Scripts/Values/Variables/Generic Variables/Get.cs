using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class Get<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IGet<T> value;
        public T Value { get => value.Value; set => throw new System.NotImplementedException(); }
    }
}
