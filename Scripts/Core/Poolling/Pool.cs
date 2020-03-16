using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public class Pool<T> : IPool<T>
    {
        protected Stack<T> pool = new Stack<T>();
        public virtual bool TryGetValue(out T value)
        {
            if (pool.Count <= 0)
            {
                value = default;
                return false;
            }
            value = pool.Pop();
            return true;
        }

        public virtual void SetValue(T value)
        {
            pool.Push(value);
        }

        public virtual void Clear()
        {
            pool.Clear();
        }
    }
}