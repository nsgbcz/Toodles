using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class RigidbodyComponent : IECSComponent
    {
        public Rigidbody Rigidbody;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<RigidbodyComponent>().Rigidbody = Rigidbody;
        }
    }
    public class RigidbodyComponentView : IECSComponent
    {
        public IGet<Rigidbody> Rigidbody;

        public void DressEntity(EcsEntity entity)
        {
            entity.Set<RigidbodyComponent>().Rigidbody = Rigidbody.Value;
        }
    }
}
