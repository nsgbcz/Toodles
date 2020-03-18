﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs.Creators
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsSystemsHandler")]
    public class GlobalEcsSystemsHandler : GlobalVariable<EcsSystemsRegistrator>, IInit, IRun
    {
        public void Init()
        {
            Value.Init();
        }

        public void Run()
        {
            Value.Run();
        }
    }
}
