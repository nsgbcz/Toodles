using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles 
{
    public class Instantiator<T> : IInstantiator<T>, IVar<IInstantiator<T>> where T : Object
    {
        [SerializeField, AssetSelector]
        T Prefab;
        [SerializeField]
        IPool<T> Pool;

        public IInstantiator<T> Value { get => this; set => throw new System.NotImplementedException(); }

        public T Instantiate()
        {
            if(Pool.TryGetValue(out var value)) return value;

            return GameObject.Instantiate<T>(Prefab);
        }
        public T Instantiate(Transform parent)
        {
            if (Pool.TryGetValue(out var value)) return value;

            return GameObject.Instantiate<T>(Prefab, parent);
        }
        public T Instantiate(Quaternion rotation, Vector3 position)
        {
            if (Pool.TryGetValue(out var value)) return value;

            return GameObject.Instantiate<T>(Prefab, position, rotation);
        }
        public T Instantiate(Quaternion rotation, Vector3 position, Transform parent)
        {
            if (Pool.TryGetValue(out var value)) return value;

            return GameObject.Instantiate<T>(Prefab, position, rotation, parent);
        }
        public T Instantiate(Transform parent, bool worldPositionStays)
        {
            if(Pool.TryGetValue(out var value)) return value;

            return GameObject.Instantiate<T>(Prefab, parent, worldPositionStays);
        }
    }
}