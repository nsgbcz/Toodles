using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.ECS
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
    public class OnDisposeComponentView : IECSComponent
    {
        public IAction OnDispose;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<OnDisposeComponent>().OnDispose += OnDispose.Action;
        }
    }
}
