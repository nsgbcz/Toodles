using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class AddForceComponent : IECSComponent
    {
        public Vector3 Force;
        public ForceMode Mode = ForceMode.Impulse;
        public void DressEntity(EcsEntity entity)
        {
            var c = entity.Set<AddForceComponent>();
            c.Force = Force;
            c.Mode = Mode;
        }
    }
}
