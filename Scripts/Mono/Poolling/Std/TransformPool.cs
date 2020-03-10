using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Variables
{
    public class TransformPool : Pool<Transform>
    {
        static Transform _pool;
        static Transform Pool
        {
            get
            {
                if (_pool == null)
                {
                    var pool = GameObject.Find("Pool");
                    if (pool == null)
                    {
                        pool = new GameObject("Pool");
                    }
                    _pool = pool.transform;
                }
                return _pool;
            }
        }
        public override bool TryGetValue(out Transform value)
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
        public override void SetValue(Transform value)
        {
            value.SetParent(Pool);
            base.SetValue(value);
        }
    }
}