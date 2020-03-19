using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.ECS.Creators
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsSystemsHandler")]
    public class GlobalEcsSystemsHandler : GlobalVariable<SystemsECS>, IInit, IRun
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
