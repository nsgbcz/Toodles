using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public class ScenePool<T> : Pool<T> where T: Component
    {
        static Transform _pool;
        public static Transform Pool
        {
            get
            {
                if (_pool == null)
                {
                    var pool = GameObject.Find("Pool");
                    if (pool == null)
                    {
                        pool = new GameObject("Pool");
                        GameObject.DontDestroyOnLoad(pool);
                    }
                    _pool = pool.transform;
                    pool.SetActive(false);
                }
                return _pool;
            }
        }
        public override bool TryGetValue(out T value)
        {
            do
            {
                if (pool.Count > 0)
                    value = pool.Pop();
                else
                {
                    value = null;
                    return false;
                }
            }
            while (value == null);
            return true;
        }
        public override void SetValue(T value)
        {
            value.transform.SetParent(Pool);
            base.SetValue(value);
        }
    }
}