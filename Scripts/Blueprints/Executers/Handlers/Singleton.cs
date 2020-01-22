using System.Collections.Generic;
using UnityEngine;
using System;

namespace BP
{
    [Obsolete]
    /// <summary>
    /// Was created like super class for all singletons.
    /// </summary>
    public class Singleton : MonoBehaviour
    {
        //public enum SingletonType { }
        //public SingletonType type;
        //static Dictionary<SingletonType, GameObject> singletons = new Dictionary<SingletonType, GameObject>();

        static Dictionary<Type, GameObject> singletons = new Dictionary<Type, GameObject>();
        void OnEnable()
        {
            GameObject obj;
            var type = GetType();
            if (singletons.TryGetValue(type, out obj))
            {
                singletons.Remove(type);
                Destroy(obj);
            }
            singletons.Add(type, gameObject);
        }

        void OnDisable()
        {
            singletons.Remove(GetType());
        }
    }
}
