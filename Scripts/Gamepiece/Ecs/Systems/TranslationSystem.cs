using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Gamepiece
{
    using Ecs;
    public class TranslationSystem : IEcsRunSystem
    {
        EcsFilter<ITransformComponent, ITranslationComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var transform = _filter.Get1[i].Transform;
                var translation = _filter.Get2[i];

                transform.Translate(translation.Translation, Space.World);

                translation.Translation = Vector3.zero;
            }
        }
    }
}
