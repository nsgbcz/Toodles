using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Ecs
{
    using Leopotam.Ecs.Reactive;
    using Leopotam.Ecs;

    public class DisposeSistem : EcsReactiveSystem<EcsFilter<DisposeComponent>>
    {
        EcsFilter<DisposeComponent, OnDisposeComponent> OnDisposeFilter;

        protected override EcsReactiveType GetReactiveType()
        {
            return EcsReactiveType.OnAdded;
        }

        protected override void RunReactive()
        {
            foreach (var i in OnDisposeFilter)
            {
                OnDisposeFilter.Get2[i].OnDispose?.Invoke();
            }
            foreach (ref var entity in this)
            {
                entity.Destroy();
            }
        }
    }
}
