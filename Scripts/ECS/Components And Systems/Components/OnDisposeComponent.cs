using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Ecs
{
    using Leopotam.Ecs;

    public class OnDisposeComponent// : IECSComponent
    {
        [HideInInspector]
        public Action OnDispose;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<OnDisposeComponent>();
        }
    }
    public class OnDisposeComponentView : IComponentEcs
    {
        public IAction OnDispose;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<OnDisposeComponent>().OnDispose += OnDispose.Action;
        }
    }
}
