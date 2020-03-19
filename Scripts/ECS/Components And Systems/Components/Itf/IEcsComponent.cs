using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.ECS
{
    [AssetSelector]
    public interface IECSComponent
    {
        void DressEntity(EcsEntity entity);

    }
}
