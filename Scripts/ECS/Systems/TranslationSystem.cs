using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public class TranslationSystem : IEcsRunSystem
    {
        EcsFilter<TransformData, TranslationData> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var transform = _filter.Get1[i].Value;
                var translation = _filter.Get2[i].Value;

                transform.Translate(translation, Space.World);
            }
        }
    }
}
