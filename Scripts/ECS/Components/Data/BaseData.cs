using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs 
{
    public abstract class BaseData<T> : IEcsComponent where T : BaseData<T>
    {
        public void DressEntity(EcsEntity entity)
        {
            SetValue(entity.Set<T>());
        }

        protected abstract void SetValue(T component);
    }
}