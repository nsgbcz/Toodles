using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Mono
{
    public class MonoContainer : SerializedMonoBehaviour, IContainer
    {
        public IContainer container = new Container();

        public void SetValue<T>(string key, T value) where T: IContent
        {
            container.SetValue<T>(key, value);
        }
        public bool TryGetValue<T>(string key, out T value) where T : IContent
        {
            return container.TryGetValue<T>(key, out value);
        }
    }
}
