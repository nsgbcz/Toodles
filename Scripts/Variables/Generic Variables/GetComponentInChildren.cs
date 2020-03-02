using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class GetComponentInChildren<T> : IGet<T>
    {
        [SerializeField, Required, HideLabel]
        IGet<GameObject> value;
        public T Value => value.Value.GetComponentInChildren<T>();
    }
}
