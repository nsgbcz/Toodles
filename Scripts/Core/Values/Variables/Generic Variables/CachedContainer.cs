using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    using Mono;

    public class CachedContainer<T> : IVar<T> where T : IContent
    {
        [AssetSelector, SerializeField, Required]
        IGet<string> key;
        [AssetSelector, SerializeField, Required]
        IContainer container;

        IVar<T> cache;
        public T Value
        {
            get
            {
                Init();
                return cache.Value;
            }
            set => cache.Value = value;
        }

        void Init()
        {
            if (cache != null) return;

            cache = new Val<T>();
            if (container.TryGetValue(key.Value, out T value))
                cache.Value = value;
            ApplicationQuitHandler.Subscribe(Reset);
        }

        /// <summary>
        /// Needs reset cause SerializableObjects don't do that.
        /// </summary>
        void Reset()
        {
            cache = null;
        }
    }
}
