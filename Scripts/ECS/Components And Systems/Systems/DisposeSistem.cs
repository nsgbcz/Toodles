using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.ECS
{
    using Leopotam.Ecs;

    public class DisposeSistem : IEcsRunSystem
    {
        EcsFilter<DisposeComponent> DisposeFilter;
        EcsFilter<DisposeComponent, OnDisposeComponent> OnDisposeFilter;

        public void Run()
        {
            foreach (var i in OnDisposeFilter)
            {
                OnDisposeFilter.Get2[i].OnDispose?.Invoke();
            }
            foreach (var i in DisposeFilter)
            {
                DisposeFilter.Entities[i].Destroy();
            }
        }
    }
}
