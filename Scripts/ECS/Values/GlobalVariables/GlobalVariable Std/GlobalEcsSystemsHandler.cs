using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs.Creators
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsSystemsHandler")]
    public class GlobalEcsSystemsHandler : GlobalVariable<EcsSystemsHandler>, IInit, IRun
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
