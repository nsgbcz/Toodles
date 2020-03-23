using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsComponent")]
    public class GlobalEcsComponent : GlobalVariable<IComponentEcs>, IComponentEcs
    {
        public void DressEntity(EcsEntity entity)
        {
            Value.DressEntity(entity);
        }
    }
}
