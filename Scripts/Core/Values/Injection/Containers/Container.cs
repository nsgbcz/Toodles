using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public class Container : IContainer
    {
        [SerializeField] Dictionary<string, IVar<IContent>> values = new Dictionary<string, IVar<IContent>>();

        public void SetValue<T>(string key, T value) where T : IContent
        {
            if (values.ContainsKey(key))
            {
                values.Remove(key);
            }
            values.Add(key, new Val<IContent>(value));
        }

        public bool TryGetValue<T>(string key, out T value) where T : IContent
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