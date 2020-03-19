using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class TranslateComponent : IECSComponent
    {
        public Vector3 Translation;
        public Space Space = Space.World;
        public void DressEntity(EcsEntity entity)
        {
            var c = entity.Set<TranslateComponent>();
            c.Translation = Translation;
            c.Space = Space;
        }
    }
}
