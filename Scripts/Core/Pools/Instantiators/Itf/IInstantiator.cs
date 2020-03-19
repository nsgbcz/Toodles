using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public interface IInstantiator<T> where T : Object
    {
        T Instantiate();
        T Instantiate(Transform parent);
        T Instantiate(Quaternion rotation, Vector3 position);
        T Instantiate(Quaternion rotation, Vector3 position, Transform parent);
        T Instantiate(Transform parent, bool worldPositionStays);
    }
}
