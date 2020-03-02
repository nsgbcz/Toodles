using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    using Containers;
    public class Container<T> : IVar<T> where T : IContainable
    {
        [AssetSelector]
        [SerializeField, Required] 
        IGet<string> key;
        [AssetSelector]
        [SerializeField, Required] 
        IContainer container;

        public T Value
        {
            get
            {
                T result;
                var key = this.key.Value;
                if (container.TryGetValue<T>(key, out result)) return result;

                throw new System.Exception("Key is invalid or Type missing");
            }
            set => container.SetValue(key.Value, value);
        }
    }
}
