using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class TranslationSystem : IEcsRunSystem
    {
        EcsFilter<TransformComponent, TranslateComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var transform = _filter.Get1[i].Transform;
                var translate = _filter.Get2[i];

                transform.Translate(translate.Translation, Space.World);
                translate.Translation = Vector3.zero;
            }
        }
    }
}
