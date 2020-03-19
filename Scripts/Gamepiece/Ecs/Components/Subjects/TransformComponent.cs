using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class TransformComponent : IECSComponent
    {
        public Transform Transform;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<TransformComponent>().Transform = Transform;
        }
    }
    public class TransformComponentView : IECSComponent
    {
        public IGet<Transform> Transform;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<TransformComponent>().Transform = Transform.Value;
        }
    }
}
