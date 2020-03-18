using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Gamepiece
{
    using Ecs;
    public class TranslationSystem : IEcsRunSystem
    {
        EcsFilter<TransformComponent, TranslationComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var transform = _filter.Get1[i].Data;
                var translation = _filter.Get2[i].Data;

                transform.Translate(translation, Space.World);

                _filter.Get2[i].Data = Vector3.zero;
            }
        }
    }
}
