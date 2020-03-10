using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Variables.Injection
{ 
    public interface IContainer
    {
        void SetValue<T>(string key, T value) where T: IContent;
        bool TryGetValue<T>(string key, out T value) where T : IContent;
    }
}
