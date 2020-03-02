using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public class CachedValue<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value;

        IVar<T> cache;  //Replace with bool, save cached value to "value" variable. Reset when application quit (in otherwise ScriptableObjects will crush this behaviour after calling in the Unity).
        public T Value
        {
            get
            {
                if (cache == null)
                    cache = new Value<T>(value.Value);
                return cache.Value;
            }
            set => cache.Value = value;
        }
    }
}
