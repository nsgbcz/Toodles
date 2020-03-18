using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs 
{
    public abstract class BaseComponent<T> : IEcsComponent where T : class
    {
        public virtual void DressEntity(EcsEntity entity)
        {
            SetValue(entity.Set<T>());
        }
        protected virtual void SetValue(T component) { }
    }
}