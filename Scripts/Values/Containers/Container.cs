using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Variables.Containers
{
    public class Container : IContainer
    {
        [SerializeField] Dictionary<string, IVar<IContainable>> values = new Dictionary<string, IVar<IContainable>>();

        public void SetValue<T>(string key, T value) where T : IContainable
        {
            if (values.ContainsKey(key))
            {
                values.Remove(key);
            }
            values.Add(key, new Value<IContainable>(value));
        }

        public bool TryGetValue<T>(string key, out T value) where T : IContainable
        {
            if (values.TryGetValue(key, out var var))
            {
                var temp = var.Value;
                if (temp is T)
                {
                    value = (T)temp;
                    return true;
                }
            }
            value = default;
            return false;
        }
    }
}