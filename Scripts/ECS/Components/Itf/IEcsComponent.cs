using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public interface IEcsComponent
    {
        void DressEntity(EcsEntity entity);
    }
}
