using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public interface IPool<T>
    {
        void SetValue(T value);
        bool TryGetValue(out T value);
        void Clear();
    }
}
