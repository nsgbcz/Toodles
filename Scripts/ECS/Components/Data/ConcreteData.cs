using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs 
{
    public abstract class ConcreteData<T, T1> : BaseData<T1> where T1 : ConcreteData<T, T1>
    {
        public T Value;
        protected override void SetValue(T1 component)
        {
            component.Value = Value;
        }
    }
}