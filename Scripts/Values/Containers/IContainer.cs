using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Variables.Containers
{ 
    public interface IContainer
    {
        void SetValue<T>(string key, T value) where T: IContainable;
        bool TryGetValue<T>(string key, out T value) where T : IContainable;
    }
}
