using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.ECS
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsComponent")]
    public class GlobalEcsComponent : GlobalVariable<IECSComponent>, IECSComponent
    {
        public void DressEntity(EcsEntity entity)
        {
            Value.DressEntity(entity);
        }
    }
}
