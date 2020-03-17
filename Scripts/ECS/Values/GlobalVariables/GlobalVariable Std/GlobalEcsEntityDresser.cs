﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsEntityDresser")]
    public class GlobalEcsEntityDresser : GlobalVariable<IEcsComponent>, IEcsComponent
    {
        public void DressEntity(EcsEntity entity)
        {
            Value.DressEntity(entity);
        }
    }
}