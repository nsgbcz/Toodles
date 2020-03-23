using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    [AssetSelector]
    public interface IComponentEcs
    {
        void DressEntity(EcsEntity entity);
    }
}
