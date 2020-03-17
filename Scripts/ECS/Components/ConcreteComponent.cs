using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public abstract class ConcreteComponent<T, T1> : BaseComponent<T1> where T1 : ConcreteComponent<T, T1>
    {
        public T Data; 
        protected override void SetValue(T1 component)
        {
            component.Data = Data;
        }
    }
}